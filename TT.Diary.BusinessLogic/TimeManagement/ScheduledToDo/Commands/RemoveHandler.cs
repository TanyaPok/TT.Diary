using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ScheduledToDo.Commands
{
    public class RemoveHandler : AbstractRemoveTrackedHandler<RemoveCommand, ToDo>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}
