using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.BaseValidation;
using TT.Diary.BusinessLogic.Lists.Habits.Commands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, Habit>
    {
        public RemoveCommandValidator(DiaryDBContext dbContext) : base(dbContext, ValidationMessages.IsScheduled.GetDescription())
        {
        }
    }
}