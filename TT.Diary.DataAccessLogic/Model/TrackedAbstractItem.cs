using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.DataAccessLogic.Model
{
    public abstract class TrackedAbstractItem : AbstractItem
    {
        public IList<Tracker> Trackers { set; get; }
    }
}
