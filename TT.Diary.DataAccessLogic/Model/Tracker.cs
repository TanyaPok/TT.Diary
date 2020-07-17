using System;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Tracker : AbstractEntity
    {
        public DateTime DateUtc { set; get; }
        public double Value { set; get; }
    }
}