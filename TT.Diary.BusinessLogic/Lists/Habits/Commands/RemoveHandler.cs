using TT.Diary.BusinessLogic.Lists.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Habit>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}