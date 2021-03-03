using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.WishSchedule.Commands
{
    public class SetHandler : AbstractSetScheduledHandler<SetCommand, Wish>
    {
        public SetHandler(WishListContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}