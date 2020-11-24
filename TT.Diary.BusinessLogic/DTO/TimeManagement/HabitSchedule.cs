using System;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class HabitSchedule : AbstractItem
    {
        public uint? Amount { get; set; }

        public ScheduleSettings Shedule { get; set; }

        public ScheduleSettings ScheduleSettings { get; set; }

        public DateTime DateUtc { set; get; }

        public int Progress { set; get; }
    }
}
