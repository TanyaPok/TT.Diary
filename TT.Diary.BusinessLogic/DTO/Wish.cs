namespace TT.Diary.BusinessLogic.DTO
{
    public class Wish : AbstractComponent
    {
        public string Author { set; get; }
        public DataAccessLogic.Model.TypeList.Rating Rating { set; get; }
    }
}