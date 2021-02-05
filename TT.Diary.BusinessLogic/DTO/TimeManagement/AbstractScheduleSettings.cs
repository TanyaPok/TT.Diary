using System;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public abstract class AbstractScheduleSettings
    {
        public int Id { get; set; }

        public DateTime ScheduledStartDateTime { set; get; }

        public DateTime? ScheduledCompletionDate { set; get; }

        public DateTime? CompletionDate { set; get; }
    }
}
