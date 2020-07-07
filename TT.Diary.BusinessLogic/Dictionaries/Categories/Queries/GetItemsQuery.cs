using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetItemsQuery : IRequest<ViewModel.Category>
    {
        public int Id { get; set; }
    }
}