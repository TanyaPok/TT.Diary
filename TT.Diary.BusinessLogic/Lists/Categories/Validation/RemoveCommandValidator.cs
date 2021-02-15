using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.Categories.Commands;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.Categories.Validation
{
    public class RemoveCommandValidator : AbstractValidator<RemoveCommand>
    {
        public RemoveCommandValidator(CategoriesContainerRepository repository)
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.Id == 0)
                    return;

                if (repository.IsRootCategory(command.Id))
                {
                    context.AddFailure(ValidationMessages.IsRootCategory.GetDescription());
                    return;
                }

                if (repository.HasChildren(command.Id))
                {
                    context.AddFailure(ValidationMessages.HasNestedItems.GetDescription());
                }
            });
        }
    }
}