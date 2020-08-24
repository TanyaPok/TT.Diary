using System;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class HabitSchedule : AbstractComponent
    {
        public int? Amount { get; set; }
        public Schedule Shedule { get; set; }
        public ScheduleSettings ScheduleSettings { get; set; }
        public DateTime DateUtc { set; get; }
        public int Progress { set; get; }
    }
}
