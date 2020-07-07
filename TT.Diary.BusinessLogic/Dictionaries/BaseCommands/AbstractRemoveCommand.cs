using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseCommands
{
    public class AbstractRemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}