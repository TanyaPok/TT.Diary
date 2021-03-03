using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.WishSchedule.Commands
{
    public class RemoveHandler : AbstractRemoveScheduleHandler<RemoveCommand, Wish>
    {
        public RemoveHandler(WishListContainerRepository repository, ScheduleSettingsRepository scheduleRepository) 
            : base(repository, scheduleRepository)
        {
        }
    }
}