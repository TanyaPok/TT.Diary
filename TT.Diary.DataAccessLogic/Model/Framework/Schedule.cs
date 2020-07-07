using System;
using System.Collections.Generic;

namespace TT.Diary.DataAccessLogic.Model.Framework
{
    public class Schedule : AbstractEntity
    {
        public DateTime ScheduledStartDateUtc { set; get; }
        public DateTime? StartDateUtc { set; get; }
        public DateTime? ScheduledCompletionDateUtc { set; get; }
        public DateTime? CompletionDateUtc { set; get; }
        public IList<Tracker> Trackers { set; get; }
    }
}