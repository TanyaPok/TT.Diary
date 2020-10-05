using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetItemsQuery : IRequest<Category<Habit>>
    {
        public int UserId { get; set; }
    }
}