using System;

namespace TT.Diary.DataAccessLogic.Model.Framework
{
    public class Tracker : AbstractEntity
    {
        public DateTime DateUtc { set; get; }
        public double Value { set; get; }
    }
}