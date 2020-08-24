using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.DataAccessLogic.Model.TypeList
{
    public class Appointment : AbstractItem
    {
        public IList<Tracker> Trackers { set; get; }
        public ScheduleSettings ScheduleSettings { set; get; }
    }
}
