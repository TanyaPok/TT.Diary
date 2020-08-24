using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Dictionaries.Habits.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Habit>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}