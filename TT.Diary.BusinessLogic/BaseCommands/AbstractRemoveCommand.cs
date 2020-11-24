using MediatR;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}