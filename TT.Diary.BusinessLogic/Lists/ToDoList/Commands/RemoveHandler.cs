using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, ToDo>
    {
        public RemoveHandler(ToDoListContainerRepository repository) : base(repository)
        {
        }
    }
}