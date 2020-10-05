using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Queries
{
    public class GetItemsQuery : IRequest<Category<ToDo>>
    {
        public int UserId { get; set; }
    }
}
