using MediatR;

namespace TT.Diary.BusinessLogic.Lists.BaseCommands
{
    public abstract class AbstractRemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}