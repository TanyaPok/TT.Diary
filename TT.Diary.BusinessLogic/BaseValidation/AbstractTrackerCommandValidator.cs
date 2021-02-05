using FluentValidation;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;

namespace TT.Diary.BusinessLogic.BaseValidation
{
    public abstract class AbstractTrackerCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : AbstractAddTrackerCommand
    {
        public AbstractTrackerCommandValidator()
        {
            RuleFor(r => r.OwnerId).GreaterThan(0).WithMessage(ValidationMessages.InvalidOwnerTrackerId.GetDescription());
        }
    }
}
