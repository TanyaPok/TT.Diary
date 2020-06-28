using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Validation
{
    public class RemoveCommandValidator : AbstractValidator<RemoveCommand>
    {
        public RemoveCommandValidator(DiaryDBContext dbContext)
        {
            RuleFor(r => r).Custom((command, context) =>
                {
                    var book = dbContext.Get<Wish, Schedule>(command.Id, c => c.Schedule);
                    var isForbidden = book.Schedule != null && book.Schedule.CompletionDateUtc == null;
                    if (isForbidden)
                    {
                        context.AddFailure(ValidationMessages.WishOnSchedule.GetDescription());
                    }
                });
        }
    }
}