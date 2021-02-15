using System;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public abstract class AbstractQuery
    {
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
    }
}