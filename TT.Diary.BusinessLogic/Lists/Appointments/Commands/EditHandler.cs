using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Appointments.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, Appointment>
    {
        public EditHandler(AppointmentsContainerRepository repository, IMapper mapper) : base(repository, mapper,
            c => c.Appointments)
        {
        }
    }
}