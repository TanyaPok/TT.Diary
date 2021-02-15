using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitTracker.Commands
{
    public class RemoveHandler : AbstractRemoveTrackerHandler<Habit, RemoveCommand>
    {
        public RemoveHandler(TrackedHabitsContainerRepository repository) : base(repository)
        {
        }
    }
}