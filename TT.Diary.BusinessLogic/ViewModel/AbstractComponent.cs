namespace TT.Diary.BusinessLogic.ViewModel
{
    public abstract class AbstractComponent
    {
        public int Id { get; set; }
        public string Description { set; get; }
        public Schedule Schedule { set; get; }
    }
}