using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentTracker.Commands
{
    public class RemoveHandler : AbstractRemoveTrackerHandler<Appointment, RemoveCommand>
    {
        public RemoveHandler(TrackedAppointmentsContainerRepository repository) : base(repository)
        {
        }
    }
}