using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Books.Commands
{
    public class RemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}