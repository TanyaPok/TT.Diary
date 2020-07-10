using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.ToDoList.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, ToDo>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}
