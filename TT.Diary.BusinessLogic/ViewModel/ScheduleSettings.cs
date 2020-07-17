using System;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.ViewModel
{
    public class ScheduleSettings
    {
        public int Id { get; set; }
        public Repeat Repeat { get; set; }
        public int Gap { get; set; }
        public RepeatEvery RepeatEvery { get; set; }
        public Weekdays Weekdays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
