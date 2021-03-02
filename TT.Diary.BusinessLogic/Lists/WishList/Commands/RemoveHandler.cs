using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Wish>
    {
        public RemoveHandler(WishListContainerRepository repository) : base(repository)
        {
        }
    }
}