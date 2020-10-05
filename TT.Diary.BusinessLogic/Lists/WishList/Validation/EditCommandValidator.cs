using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.BaseValidation;
using TT.Diary.BusinessLogic.Lists.WishList.Commands;

namespace TT.Diary.BusinessLogic.Lists.WishList.Validation
{
    public class EditCommandValidator : AbstractCommandValidator<EditCommand>
    {
        public EditCommandValidator() : base()
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());
        }
    }
}