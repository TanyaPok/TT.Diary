using MediatR;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveTrackerCommand : IRequest
    {
        public int OwnerId { get; set; }
    }
}