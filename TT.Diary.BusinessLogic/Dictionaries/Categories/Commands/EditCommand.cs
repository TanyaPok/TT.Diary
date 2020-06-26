using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class EditCommand : IRequest
    {
        public int Id { set; get; }
        public string Description { get; set; }
        public int CategoryId { set; get; }
        public int OldCategoryId { set; get; }
    }
}