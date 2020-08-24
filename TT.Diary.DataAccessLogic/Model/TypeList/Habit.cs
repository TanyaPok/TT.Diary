using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.DataAccessLogic.Model.TypeList
{
    public class Habit : AbstractItem
    {
        public int? Amount { set; get; }
        public IList<Tracker> Trackers { set; get; }
        public ScheduleSettings ScheduleSettings { set; get; }
    }
}