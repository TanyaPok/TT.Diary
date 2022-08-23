using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ToDoPriority.Commands
{
    public class SetHandler : AbstractSetPriorityHandler<SetCommand, ToDo>
    {
        public SetHandler(ToDoListContainerRepository repository) : base(repository)
        {
        }
    }
}