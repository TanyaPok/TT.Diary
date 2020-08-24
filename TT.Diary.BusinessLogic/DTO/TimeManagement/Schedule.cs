using System;

namespace TT.Diary.BusinessLogic.DTO
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime ScheduledStartDateUtc { set; get; }
        public DateTime? StartDateUtc { set; get; }
        public DateTime? ScheduledCompletionDateUtc { set; get; }
        public DateTime? CompletionDateUtc { set; get; }
    }
}
