using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseValidation;
using TT.Diary.BusinessLogic.Lists.Appointments.Commands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Appointments.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, Appointment>
    {
        public RemoveCommandValidator(AppointmentsContainerRepository repository) : base(repository,
            ValidationMessages.IsScheduled.GetDescription())
        {
        }
    }
}