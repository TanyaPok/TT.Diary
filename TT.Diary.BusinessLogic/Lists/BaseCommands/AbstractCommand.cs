using MediatR;

namespace TT.Diary.BusinessLogic.Lists.BaseCommands
{
    public abstract class AbstractCommand : IRequest<int>
    {
        public int CategoryId { set; get; }

        public string Description { set; get; }
    }
}