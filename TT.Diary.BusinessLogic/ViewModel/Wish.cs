namespace TT.Diary.BusinessLogic.ViewModel
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

    public class Wish : AbstractComponent
    {
        public string Author { set; get; }
        public Rating Rating { set; get; }
    }
}