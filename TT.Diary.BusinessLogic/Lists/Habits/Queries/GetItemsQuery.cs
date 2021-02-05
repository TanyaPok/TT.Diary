using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetItemsQuery : IRequest<Category<Habit<ScheduleSettingsSummary>>>
    {
        public int UserId { get; set; }

        public bool OnlyUnscheduled { get; set; }
    }
}