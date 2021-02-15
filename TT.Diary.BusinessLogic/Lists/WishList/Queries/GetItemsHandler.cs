using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Queries
{
    public class
        GetItemsHandler : IRequestHandler<GetItemsQuery, DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>>
    {
        private readonly IMapper _mapper;
        private readonly WishListContainerRepository _repository;

        public GetItemsHandler(WishListContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>> Handle(GetItemsQuery request,
            CancellationToken cancellationToken)
        {
            var category = _repository.GetAllLevels(request.UserId, c => c.WishList);
            var result = _mapper.Map<Category, DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>>(category);
            return Task.FromResult(result);
        }
    }
}