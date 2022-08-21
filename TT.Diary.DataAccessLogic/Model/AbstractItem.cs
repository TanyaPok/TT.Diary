using System;
using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.DataAccessLogic.Model
{
    public enum Priority
    {
        None,
        ImportantAndUrgent,
        ImportantAndNotUrgent,
        NotImportantUrgent,
        NotImportantNotUrgent
    }

    public abstract class AbstractItem : AbstractComponent
    {
        #region DB settings

        public int CategoryId { set; get; }

        public Category Category { set; get; }

        public int? ScheduleId { get; set; }

        public Priority Priority { get; set; }

        public DateTime PriorityModifyDateTimeUtc { get; set; }

        #endregion

        public ScheduleSettings Schedule { get; set; }
    }
}