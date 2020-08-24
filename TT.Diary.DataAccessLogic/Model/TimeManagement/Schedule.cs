using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT.Diary.DataAccessLogic.Model.TimeManagement
{
    public class Schedule : AbstractEntity
    {
        #region DB settings
        [NotMapped]
        public AbstractItem Owner { set; get; }
        #endregion
        public DateTime ScheduledStartDateUtc { set; get; }
        public DateTime? StartDateUtc { set; get; }
        public DateTime? ScheduledCompletionDateUtc { set; get; }
        public DateTime? CompletionDateUtc { set; get; }
    }
}