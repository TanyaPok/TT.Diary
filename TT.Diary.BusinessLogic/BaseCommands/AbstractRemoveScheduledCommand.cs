using MediatR;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public class AbstractRemoveScheduledCommand : IRequest
    {
        public int OwnerId { set; get; }

        public bool WithOwner { set; get; }
    }
}