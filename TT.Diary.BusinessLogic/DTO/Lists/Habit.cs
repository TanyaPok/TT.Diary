using System;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Habit : AbstractScheduledItem, IItem
    {
        public uint? Amount { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
    }
}
