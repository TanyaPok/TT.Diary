namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractEditCommand : AbstractCommand
    {
        public int Id { get; set; }
        public int Priority { get; set; }
    }
}