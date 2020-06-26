using System;
using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Schedule : Entity
    {
        [Required(ErrorMessage = "ScheduledStartDate")]
        public DateTime ScheduledStartDateUtc { set; get; }
        public DateTime? StartDateUtc { set; get; }
        public DateTime? ScheduledCompletionDateUtc { set; get; }
        public DateTime? CompletionDateUtc { set; get; }
    }
}