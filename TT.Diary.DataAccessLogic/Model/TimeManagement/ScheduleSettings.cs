using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT.Diary.DataAccessLogic.Model.TimeManagement
{
    public enum Repeat
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    [Flags]
    public enum Weekdays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    [Flags]
    public enum Months
    {
        January = 1,
        February = 2,
        March = 4,
        April = 8,
        May = 16,
        June = 32,
        July = 64,
        August = 128,
        September = 256,
        October = 512,
        November = 1024,
        December = 2048
    }

    public class ScheduleSettings : AbstractEntity
    {
        #region DB settings
        [NotMapped]
        public AbstractItem Owner { set; get; }
        #endregion

        public DateTime ScheduledStartDateTimeUtc { set; get; }

        public DateTime? ScheduledCompletionDateUtc { set; get; }

        public DateTime? CompletionDateUtc { set; get; }

        public Repeat Repeat { get; set; }

        public uint Every { get; set; }

        public Months Months { get; set; }

        public Weekdays Weekdays { get; set; }

        public uint DaysAmount { set; get; }
    }
}
