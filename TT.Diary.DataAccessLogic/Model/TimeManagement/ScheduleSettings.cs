using System;

namespace TT.Diary.DataAccessLogic.Model.TimeManagement
{
    [Flags]
    public enum Weekdays
    {
        All = 0x0,
        Monday = 0x1,
        Tuesday = 0x2,
        Wednesday = 0x4,
        Thursday = 0x8,
        Friday = 0x10,
        Saturday = 0x20,
        Sunday = 0x40
    }

    public enum Repeat
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Custom
    }

    public enum RepeatEvery
    {
        None,
        Day,
        Week,
        Month,
        Year
    }

    public class ScheduleSettings : AbstractEntity
    {
        public Repeat Repeat { get; set; }

        public int Gap { get; set; }

        public RepeatEvery RepeatEvery { get; set; }

        public Weekdays Weekdays { get; set; }

        public DateTime? StartDateUtc { get; set; }

        public DateTime? FinishDateUtc { get; set; }
    }
}
