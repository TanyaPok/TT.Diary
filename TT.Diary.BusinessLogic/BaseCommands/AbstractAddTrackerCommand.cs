namespace TT.Diary.BusinessLogic.BaseCommands
{
    public class AbstractAddTrackerCommand : AbstractTrackerCommand
    {
        public int OwnerId { set; get; }
    }
}
