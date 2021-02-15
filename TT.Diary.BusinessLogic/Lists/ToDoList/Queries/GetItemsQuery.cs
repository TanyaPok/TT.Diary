using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Queries
{
    public class GetItemsQuery : IRequest<Category<ToDo<ScheduleSettingsSummary>>>
    {
        public int UserId { get; set; }
    }
}