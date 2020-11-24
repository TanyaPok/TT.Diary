using System;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class Household : AbstractItem
    {
        public ScheduleSettings ScheduleSettings { set; get; }

        public DateTime DateUtc { get; set; }

        public double Value { get; set; }
    }
}
