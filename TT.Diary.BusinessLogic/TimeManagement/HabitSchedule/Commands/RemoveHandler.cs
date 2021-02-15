using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitSchedule.Commands
{
    public class RemoveHandler : AbstractRemoveScheduleHandler<RemoveCommand, ScheduleSettings>
    {
        public RemoveHandler(ScheduleRepository repository) : base(repository)
        {
        }
    }
}