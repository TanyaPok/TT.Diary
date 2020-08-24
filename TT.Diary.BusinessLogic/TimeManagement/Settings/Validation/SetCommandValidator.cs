using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Schedule.Settings.Commands;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.Schedule.Settings.Validation
{
    public class SetCommandValidator : AbstractValidator<SetCommand>
    {
        public SetCommandValidator()
        {
            RuleFor(r => r.OwnerScheduleSettingsId).GreaterThan(0).WithMessage(ValidationMessages.InvalidOwnerScheduleSettingsId.GetDescription());
            RuleFor(r => r.Repeat).NotEqual((int)Repeat.None).WithMessage(ValidationMessages.NotSetRepeat.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.Repeat == (int)Repeat.Custom && (command.Gap < 1 || command.RepeatEvery == (int)RepeatEvery.None))
                {
                    context.AddFailure(ValidationMessages.IncorrectCustomRepeatMode.GetDescription());
                }
            });
        }
    }
}
