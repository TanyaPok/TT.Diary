using System;

namespace TT.Diary.DataAccessLogic.Model.Framework
{
    public class Tracker : AbstractEntity
    {
        public DateTime Date { set; get; }
        public int Progress { set; get; }
    }
}