using System;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class ToDo : AbstractItem
    {
        public DateTime? CompletionDate { set; get; }
    }
}
