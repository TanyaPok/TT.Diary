namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Wish : AbstractScheduledItem, IItem
    {
        public string Author { set; get; }

        public DataAccessLogic.Model.TypeList.Rating Rating { set; get; }

        public int Id { set; get; }

        public string Description { set; get; }
    }
}