using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Wish>
    {
        public RemoveHandler(DiaryDBContext context) : base(context)
        {
        }
    }
}