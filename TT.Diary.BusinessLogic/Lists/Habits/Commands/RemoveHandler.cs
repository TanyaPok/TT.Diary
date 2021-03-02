using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Habit>
    {
        public RemoveHandler(HabitsContainerRepository repository) : base(repository)
        {
        }
    }
}