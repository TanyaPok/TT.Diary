using System;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Habit : AbstractItem
    {
        public uint? Amount { get; set; }

        public DateTime? CompletionDate { set; get; }
    }
}
