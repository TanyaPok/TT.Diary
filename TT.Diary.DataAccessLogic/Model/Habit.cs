using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Habit : AbstractItem
    {
        public int? Amount { set; get; }
        public IList<Tracker> Trackers { set; get; }
        public ScheduleSettings ScheduleSettings { set; get; }
    }
}