using MediatR;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public class AbstractRemoveTrackerCommand : IRequest
    {
        public int OwnerId { get; set; }
    }
}
