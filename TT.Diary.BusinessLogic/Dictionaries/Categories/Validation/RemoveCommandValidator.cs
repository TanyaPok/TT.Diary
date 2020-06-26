using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Validation
{
    public class RemoveCommandValidator : AbstractValidator<RemoveCommand>
    {
        public RemoveCommandValidator(DiaryDBContext dbContext)
        {
            RuleFor(r => r).Custom((command, context) =>
            {
                var category = dbContext.GetRecursively<Category, Book>(command.Id, c => c.Subcategories, c => c.Books);
                if (category.HasBook())
                {
                    context.AddFailure(ValidationMessages.HasNestedItems.GetDescription());
                }
            });
        }
    }
}