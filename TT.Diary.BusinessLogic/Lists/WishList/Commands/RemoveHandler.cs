using TT.Diary.BusinessLogic.Lists.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Wish>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}