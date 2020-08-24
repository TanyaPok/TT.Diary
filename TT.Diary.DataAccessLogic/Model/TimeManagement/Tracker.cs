using System;
using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model.TimeManagement
{
    public class Tracker : AbstractEntity
    {
        public DateTime DateTimeUtc { set; get; }
        [Range(0, 100, ErrorMessage = "Range of progress must be from 0 to 100.")]
        public int Progress { set; get; }
    }
}