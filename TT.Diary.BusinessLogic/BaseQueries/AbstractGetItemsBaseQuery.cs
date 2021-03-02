using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseQueries
{
    public abstract class AbstractGetItemsBaseQuery<TModel> : IRequest<Category<TModel>>
        where TModel : AbstractScheduledItem<ScheduleSettingsSummary>
    {
        public int UserId { get; set; }
        public bool OnlyUnscheduled { get; set; }
    }
}