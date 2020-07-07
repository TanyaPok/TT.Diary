using TT.Diary.DataAccessLogic.Model.Framework;

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
    public class Wish : AbstractItem
    {
        public string Author { set; get; }
        public Rating Rating { set; get; }
    }
}