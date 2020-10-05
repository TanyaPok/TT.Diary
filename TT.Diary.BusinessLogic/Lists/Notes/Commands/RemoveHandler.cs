using TT.Diary.BusinessLogic.Lists.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Note>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}