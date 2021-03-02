using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ToDoTracker.Commands
{
    public class RemoveHandler : AbstractRemoveTrackerHandler<ToDo, RemoveCommand>
    {
        public RemoveHandler(TrackedToDoListContainerRepository repository) : base(repository)
        {
        }
    }
}