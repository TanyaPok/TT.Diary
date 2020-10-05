using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.Categories.Commands;

namespace TT.Diary.BusinessLogic.Lists.Categories.Validation
{
    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator()
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty.GetDescription());

            RuleFor(r => r.UserId).GreaterThan(0).WithMessage(ValidationMessages.InvalidUserId.GetDescription());
        }
    }
}