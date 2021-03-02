using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitSchedule.Commands
{
    public class RemoveHandler : AbstractRemoveScheduleHandler<RemoveCommand, Habit>
    {
        public RemoveHandler(HabitsContainerRepository repository, ScheduleSettingsRepository scheduleRepository) 
            : base(repository, scheduleRepository)
        {
        }
    }
}