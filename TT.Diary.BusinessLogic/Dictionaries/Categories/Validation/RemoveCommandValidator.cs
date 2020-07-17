using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Validation
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

                var category = dbContext.GetRecursively<Category, AbstractItem>(command.Id,
                                c => c.Subcategories,
                                new Expression<Func<Category, IEnumerable<AbstractItem>>>[]{
                                    c => c.WishList,
                                    c => c.Habits,
                                    c => c.ToDoList});

                if (category.Has(c => c.Children != null && c.Children.OfType<AbstractItem>().Any()))
                {
                    context.AddFailure(ValidationMessages.HasNestedItems.GetDescription());
                }
            });
        }
    }
}