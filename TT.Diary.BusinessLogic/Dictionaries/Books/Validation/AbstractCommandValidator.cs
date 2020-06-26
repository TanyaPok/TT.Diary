using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Books.Commands;

namespace TT.Diary.BusinessLogic.Dictionaries.Books.Validation
{
    public abstract class AbstractCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICommand
    {
        public AbstractCommandValidator()
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty.GetDescription());
            RuleFor(r => r.CategoryId).NotEmpty().WithMessage(ValidationMessages.CategoryEmpty.GetDescription());
        }
    }
}