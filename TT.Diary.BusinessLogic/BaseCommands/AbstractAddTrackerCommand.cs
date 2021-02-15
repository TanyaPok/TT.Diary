namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractAddTrackerCommand : AbstractTrackerCommand
    {
        public int OwnerId { set; get; }
    }
}