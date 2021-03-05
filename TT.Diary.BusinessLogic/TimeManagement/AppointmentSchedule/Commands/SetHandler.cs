using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentSchedule.Commands
{
    public class SetHandler : AbstractSetScheduledHandler<SetCommand, Appointment>
    {
        public SetHandler(AppointmentsContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}