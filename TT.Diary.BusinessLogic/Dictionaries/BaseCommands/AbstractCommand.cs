namespace TT.Diary.BusinessLogic.Dictionaries.BaseCommands
{
    public abstract class AbstractCommand
    {
        public int CategoryId { set; get; }
        public string Description { set; get; }
    }
}