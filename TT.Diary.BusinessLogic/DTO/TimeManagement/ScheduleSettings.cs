using System;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class ScheduleSettings
    {
        public int Id { get; set; }

        public Repeat Repeat { get; set; }

        public int Gap { get; set; }

        public RepeatEvery RepeatEvery { get; set; }

        public Weekdays Weekdays { get; set; }

        public DateTime? StartDateUtc { get; set; }

        public DateTime? FinishDateUtc { get; set; }
    }
}
