using AutoMapper;
using MediatR;
using System;
using System.Threading;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, Category<Habit<ScheduleSettingsSummary>>>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public GetItemsHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Category<Habit<ScheduleSettingsSummary>>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetHabits(request.UserId);
            var result = _mapper.Map<Category, Category<Habit<ScheduleSettingsSummary>>>(category);
            
            if (request.OnlyUnscheduled)
            {
                RemoveScheduledItems(result);
            }

            return Task.FromResult(result);
        }

        internal void RemoveScheduledItems(Category<Habit<ScheduleSettingsSummary>> category)
        {
            for (var i = category.Items.Count - 1; i >= 0; i--)
            {
                if (category.Items[i].Schedule != null)
                {
                    category.Items.Remove(category.Items[i]);
                }
            }

            foreach (var child in category.Subcategories)
            {
                RemoveScheduledItems(child);
            }
        }
    }
}