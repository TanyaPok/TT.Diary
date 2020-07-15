using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseValidation
{
    public abstract class AbstractRemoveCommandValidator<TCommand, TModel> : AbstractValidator<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractItem
    {
        public AbstractRemoveCommandValidator(DiaryDBContext dbContext, string errorMessage)
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());
            RuleFor(r => r).Custom((command, context) =>
                {
                    var item = dbContext.Get<TModel, AbstractEntity>(command.Id, c => c.Schedule);
                    var isForbidden = item.Schedule != null && item.Schedule.CompletionDateUtc == null;
                    if (isForbidden)
                    {
                        context.AddFailure(errorMessage);
                    }
                });
        }
    }
}