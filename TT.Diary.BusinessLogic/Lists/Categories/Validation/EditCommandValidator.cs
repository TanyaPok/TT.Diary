using FluentValidation;
using TT.Diary.BusinessLogic.Lists.Categories.Commands;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.Categories.Validation
{
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator(CategoriesContainerRepository repository)
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty.GetDescription());

            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.Id == 0)
                    return;

                var category = repository.GetFirstLevel(
                    command.Id,
                    c => c.Subcategories);

                if (category.Has(c => c.Id == command.CategoryId))
                {
                    context.AddFailure(ValidationMessages.InvalidParent.GetDescription());
                }
            });
        }
    }
}