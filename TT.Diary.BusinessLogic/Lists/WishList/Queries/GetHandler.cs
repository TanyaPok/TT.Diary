using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Lists.WishList.Queries
{
    public class GetHandler : GetBaseHandler<DTO.Lists.Wish<ScheduleSettingsSummary>, DataAccessLogic.Model.TypeList.Wish, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}