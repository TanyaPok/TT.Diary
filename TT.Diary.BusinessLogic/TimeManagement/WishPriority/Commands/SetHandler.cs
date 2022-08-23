using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.WishPriority.Commands
{
    public class SetHandler : AbstractSetPriorityHandler<SetCommand, Wish>
    {
        public SetHandler(WishListContainerRepository repository) : base(repository)
        {
        }
    }
}