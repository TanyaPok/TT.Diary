using System;

namespace TT.Diary.DataAccessLogic.Model.PublicUtilities
{
    public class PublicUtilityTracker : AbstractEntity
    {
        public DateTime DateUtc { get; set; }
        public double Value { get; set; }
    }
}
