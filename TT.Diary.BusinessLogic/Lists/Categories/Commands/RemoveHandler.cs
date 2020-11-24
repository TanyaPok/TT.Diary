using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Category>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}