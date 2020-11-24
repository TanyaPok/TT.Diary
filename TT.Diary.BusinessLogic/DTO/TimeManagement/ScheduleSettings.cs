using System;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class ScheduleSettings
    {
        public int Id { set; get; }

        public DateTime ScheduledStartDateTime { set; get; }

        public DateTime? ScheduledCompletionDate { set; get; }

        public DateTime? CompletionDate { set; get; }

        public Repeat Repeat { get; set; }

        public uint Every { get; set; }

        public Months Months { get; set; }

        public Weekdays Weekdays { get; set; }

        public uint DaysAmount { set; get; }
    }
}
