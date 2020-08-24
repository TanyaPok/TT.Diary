using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO
{
    public class Habit : AbstractComponent
    {
        public int? Amount { get; set; }
        public ScheduleSettings Settings { get; set; }
    }
}