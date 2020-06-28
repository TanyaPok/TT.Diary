namespace TT.Diary.DataAccessLogic.Model
{
    public enum Rating
    {
        Empty,
        Trash,
        NotSoBad,
        Normal,
        Good,
        Fire
    }
    public class Wish : AbstractToDo
    {
        public string Author { set; get; }
        public Rating Rating { set; get; }
    }
}