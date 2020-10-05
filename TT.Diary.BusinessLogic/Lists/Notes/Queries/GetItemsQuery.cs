using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.Lists.Notes.Queries
{
    public class GetItemsQuery : IRequest<Category<Note>>
    {
        public int UserId { get; set; }
    }
}