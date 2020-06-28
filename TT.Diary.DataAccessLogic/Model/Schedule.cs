using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Schedule : AbstractEntity
    {
        [Required(ErrorMessage = "ScheduledStartDate")]
        public DateTime ScheduledStartDateUtc { set; get; }
        public DateTime? StartDateUtc { set; get; }
        public DateTime? ScheduledCompletionDateUtc { set; get; }
        public DateTime? CompletionDateUtc { set; get; }
        public IList<Tracker> Trackers{set;get;}
    }
}