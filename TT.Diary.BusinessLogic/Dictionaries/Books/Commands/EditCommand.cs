using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Books.Commands
{
    public class EditCommand : ICommand, IRequest
    {
        public int Id { set; get; }
        public string Description { get; set; }
        public string Author { set; get; }
        public int CategoryId { set; get; }
    }
}