using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseCommands
{
    public abstract class AbstractCommand : IRequest<int>
    {
        public int CategoryId { set; get; }
        public string Description { set; get; }
    }
}