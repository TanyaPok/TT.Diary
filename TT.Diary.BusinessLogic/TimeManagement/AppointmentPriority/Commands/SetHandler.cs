using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentPriority.Commands
{
    public class SetHandler : AbstractSetPriorityHandler<SetCommand, Appointment>
    {
        public SetHandler(AppointmentsContainerRepository repository) : base(repository)
        {
        }
    }
}