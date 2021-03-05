using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentTracker.Commands
{
    public class AddHandler : AbstractAddTrackerHandler<AddCommand, Appointment>
    {
        public AddHandler(TrackedAppointmentsContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}