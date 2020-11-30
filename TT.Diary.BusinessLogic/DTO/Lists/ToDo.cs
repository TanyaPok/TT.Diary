namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class ToDo : AbstractScheduledItem, IItem
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
