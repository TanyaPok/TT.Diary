using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseValidation
{
    public abstract class AbstractRemoveCommandValidator<TCommand, TModel> : AbstractValidator<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractItem
    {
        protected AbstractRemoveCommandValidator(AbstractBaseRepository<TModel> repository,
            string errorMessage)
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());

            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.Id == 0)
                    return;

                var item = repository.Get(command.Id, c => c.Schedule);
                if (item.Schedule != null)
                {
                    context.AddFailure(errorMessage);
                }
            });
        }
    }
}