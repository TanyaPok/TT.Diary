using System;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class Tracker
    {
        public DateTime ScheduledDate { set; get; }

        public DateTime? DateTime { set; get; }

        public byte Progress { set; get; }

        public double? Value { set; get; }

        public double Significance { set; get; }
    }
}