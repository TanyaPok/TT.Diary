using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitPriority.Commands
{
    public class SetHandler : AbstractSetPriorityHandler<SetCommand, Habit>
    {
        public SetHandler(HabitsContainerRepository repository) : base(repository)
        {
        }
    }
}