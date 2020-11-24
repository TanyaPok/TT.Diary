using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, ToDo>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}
