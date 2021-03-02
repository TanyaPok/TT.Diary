using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ToDoSchedule.Commands
{
    public class RemoveHandler : AbstractRemoveScheduleHandler<RemoveCommand, ToDo>
    {
        public RemoveHandler(ToDoListContainerRepository repository, ScheduleSettingsRepository scheduleRepository)
            : base(repository, scheduleRepository)
        {
        }
    }
}