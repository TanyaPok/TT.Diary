using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentSchedule.Commands
{
    public class RemoveHandler : AbstractRemoveScheduleHandler<RemoveCommand, Appointment>
    {
        public RemoveHandler(AppointmentsContainerRepository repository, ScheduleSettingsRepository scheduleRepository)
            : base(repository, scheduleRepository)
        {
        }
    }
}