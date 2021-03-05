using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentTracker.Commands
{
    public class EditHandler : AbstractEditTrackerHandler<EditCommand, Appointment>
    {
        public EditHandler(TrackedAppointmentsContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}