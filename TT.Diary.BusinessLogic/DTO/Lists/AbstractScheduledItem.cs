using System;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public abstract class AbstractScheduledItem
    {
        public DateTime? ScheduledStartDateTime { set; get; }

        public DateTime? ScheduledCompletionDate { set; get; }

        public DateTime? CompletionDate { set; get; }

        public bool HasSchedule => ScheduledStartDateTime.HasValue;
    }
}
