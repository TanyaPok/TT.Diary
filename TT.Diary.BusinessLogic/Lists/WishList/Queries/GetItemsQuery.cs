using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.Lists.WishList.Queries
{
    public class GetItemsQuery : IRequest<Category<Wish<ScheduleSettingsSummary>>>
    {
        public int UserId { get; set; }
    }
}