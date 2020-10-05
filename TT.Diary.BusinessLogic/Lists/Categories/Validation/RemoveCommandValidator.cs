using FluentValidation;
using System.Linq;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.Categories.Commands;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Lists.Categories.Validation
{
    public class RemoveCommandValidator : AbstractValidator<RemoveCommand>
    {
        public RemoveCommandValidator(DiaryDBContext dbContext)
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.Id == 0)
                    return;

                if (dbContext.IsRootCategory(command.Id))
                {
                    context.AddFailure(ValidationMessages.IsRootCategory.GetDescription());
                    return;
                }

                if (dbContext.Categories.AsQueryable().Any(c => c.ParentId == command.Id) ||
                    dbContext.WishList.AsQueryable().Any(w => w.CategoryId == command.Id) ||
                    dbContext.ToDoList.AsQueryable().Any(w => w.CategoryId == command.Id) ||
                    dbContext.Habits.AsQueryable().Any(w => w.CategoryId == command.Id) ||
                    dbContext.Appointments.AsQueryable().Any(w => w.CategoryId == command.Id) ||
                    dbContext.PublicUtilities.AsQueryable().Any(w => w.CategoryId == command.Id) ||
                    dbContext.Notes.AsQueryable().Any(w => w.CategoryId == command.Id))
                {
                    context.AddFailure(ValidationMessages.HasNestedItems.GetDescription());
                    return;
                }
            });
        }
    }
}