namespace TT.Diary.DataAccessLogic
{
    public interface ICategoryTitleList
    {
       string ToDoList { get; set; }
       string WishList { get; set; }
       string Habits { get; set; }
       string Notes { get; set; }
       string Appointments { get; set; }
       string PublicUtilities { get; set; }
    }
}
