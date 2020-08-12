using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Users.Commands;

namespace TT.Diary.BusinessLogic.Users.Validation
{
    public class AddCommandValidator : AbstractValidator<SetCommand>
    {
        public AddCommandValidator()
        {
            RuleFor(r => r.Sub).NotEmpty().WithMessage(ValidationMessages.SubEmpty.GetDescription());
        }
    }
}