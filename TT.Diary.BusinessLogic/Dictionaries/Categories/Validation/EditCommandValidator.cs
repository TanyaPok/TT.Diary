using FluentValidation;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.DataAccessLogic;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Validation
{
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator(DiaryDBContext dbContext)
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty.GetDescription());
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.Id == 0)
                    return;

                var category = dbContext.GetRecursively<Category>(
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