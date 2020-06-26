using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class RemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}