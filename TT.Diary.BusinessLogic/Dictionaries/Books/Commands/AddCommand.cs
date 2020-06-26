using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Books.Commands
{
    public class AddCommand : ICommand, IRequest<int>
    {
        public string Description { set; get; }
        public string Author { set; get; }
        public int CategoryId { set; get; }
    }
}