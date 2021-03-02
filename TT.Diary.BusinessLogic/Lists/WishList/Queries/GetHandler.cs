using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.WishList.Queries
{
    public class GetHandler : AbstractGetBaseHandler<DTO.Lists.Wish<ScheduleSettingsSummary>,
        DataAccessLogic.Model.TypeList.Wish, GetQuery>
    {
        public GetHandler(WishListContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}