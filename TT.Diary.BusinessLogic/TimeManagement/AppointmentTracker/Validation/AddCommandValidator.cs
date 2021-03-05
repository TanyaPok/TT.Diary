using FluentValidation;
using System;
using TT.Diary.BusinessLogic.BaseValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.TimeManagement.AppointmentTracker.Commands;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentTracker.Validation
{
    public class AddCommandValidator : AbstractTrackerCommandValidator<AddCommand>
    {
        public AddCommandValidator() : base()
        {
            RuleFor(r => r.ScheduledDate).GreaterThan(DateTime.MinValue)
                .WithMessage(ValidationMessages.NotSetDateTime.GetDescription());
        }
    }
}