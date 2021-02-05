using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public GetItemsHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetWishList(request.UserId);
            var result = _mapper.Map<Category, DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>>(category);
            return Task.FromResult(result);
        }
    }
}