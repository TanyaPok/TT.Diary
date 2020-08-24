using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.DataAccessLogic.Model.PublicUtilities
{
    public class PublicUtility : AbstractItem
    {
        public IList<PublicUtilityTracker> MeterReadingList { get; } = new List<PublicUtilityTracker>();
        public IList<PublicUtilityTracker> PublicUtilityCharges { get; } = new List<PublicUtilityTracker>();
        public ScheduleSettings ScheduleSettings { set; get; }
    }
}
