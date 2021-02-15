using AutoMapper;
using MediatR;
using System;
using System.Threading;
using TT.Diary.DataAccessLogic.Model.TypeList;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, Category<Habit<ScheduleSettingsSummary>>>
    {
        private readonly IMapper _mapper;
        private readonly HabitsContainerRepository _repository;

        public GetItemsHandler(HabitsContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<Category<Habit<ScheduleSettingsSummary>>> Handle(GetItemsQuery request,
            CancellationToken cancellationToken)
        {
            var category = (request.OnlyUnscheduled)
                ? _repository.GetAllUnscheduledLevels(request.UserId)
                : _repository.GetAllLevels(request.UserId, c => c.Habits);

            var result = _mapper.Map<Category, Category<Habit<ScheduleSettingsSummary>>>(category);
            return Task.FromResult(result);
        }
    }
}