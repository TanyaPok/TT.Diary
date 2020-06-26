using FluentValidation;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.DataAccessLogic;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Validation
{
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator(DiaryDBContext dbContext)
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                var category = dbContext.GetRecursively<Category, Category>(command.Id, c => c.Subcategories, c => c.Subcategories);

                if (category.HasCategory(command.CategoryId))
                {
                    context.AddFailure(ValidationMessages.InvalidParent.GetDescription());
                }
            });
        }
    }
}