namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractEditTrackerCommand : AbstractTrackerCommand
    {
        public int Id { get; set; }
    }
}
