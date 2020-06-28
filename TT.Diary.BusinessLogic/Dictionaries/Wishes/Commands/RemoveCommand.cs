using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands
{
    public class RemoveCommand : IRequest
    {
        public int Id { set; get; }
    }
}