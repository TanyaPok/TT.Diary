using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.Lists.WishList.Queries
{
    public class GetItemsQuery : IRequest<Category<Wish>>
    {
        public int UserId { get; set; }
    }
}
