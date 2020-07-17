using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseCommands
{
    public abstract class AbstractRemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}