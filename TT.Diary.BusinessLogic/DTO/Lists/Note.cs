using System;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Note : IItem
    {
        public DateTime ScheduleDate { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
    }
}
