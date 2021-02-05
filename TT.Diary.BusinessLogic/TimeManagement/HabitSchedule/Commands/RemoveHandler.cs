using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitSchedule.Commands
{
    public class RemoveHandler : AbstractRemoveScheduleHandler<RemoveCommand, Habit>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}
