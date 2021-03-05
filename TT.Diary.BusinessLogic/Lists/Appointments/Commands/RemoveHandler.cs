using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Appointments.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Appointment>
    {
        public RemoveHandler(AppointmentsContainerRepository repository) : base(repository)
        {
        }
    }
}