using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class AddCommand : IRequest<int>
    {
        public string Description { set; get; }
        public int CategoryId { set; get; }
    }
}