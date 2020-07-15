using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseValidation
{
    public abstract class AbstractCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : AbstractCommand
    {
        public AbstractCommandValidator()
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty.GetDescription());
            RuleFor(r => r.CategoryId).GreaterThan(0).WithMessage(ValidationMessages.InvalidCategoryId.GetDescription());
        }
    }
}