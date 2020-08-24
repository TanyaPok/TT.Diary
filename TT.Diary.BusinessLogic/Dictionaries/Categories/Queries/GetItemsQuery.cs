using MediatR;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetItemsQuery : IRequest<DTO.Category>
    {
        public int Id { get; set; }
    }
}