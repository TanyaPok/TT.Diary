using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.ViewModel
{
    public class Wish : AbstractComponent
    {
        public string Author { set; get; }
        public Rating Rating { set; get; }
    }
}