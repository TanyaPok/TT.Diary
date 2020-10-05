using System;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Wish : AbstractItem
    {
        public string Author { set; get; }

        public DataAccessLogic.Model.TypeList.Rating Rating { set; get; }

        public DateTime? CompletionDate { set; get; }
    }
}