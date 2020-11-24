using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT.Diary.DataAccessLogic.Model.TimeManagement
{
    public class Tracker : AbstractEntity
    {
        #region DB settings
        [NotMapped]
        public TrackedAbstractItem Owner { get; set; }

        public int? ToDoId { set; get; }

        public int? HabitId { set; get; }

        public int? AppointmentId { set; get; }
        #endregion

        public DateTime ScheduledDateUtc { set; get; }

        public DateTime DateTimeUtc { set; get; }

        [Range(0, 1, ErrorMessage = "Range of progress must be from 0 to 1.")]
        public byte Progress { set; get; }

        public double? Value { set; get; }
    }
}