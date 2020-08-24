using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.BaseValidation;
using TT.Diary.BusinessLogic.Dictionaries.Habits.Commands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Dictionaries.Habits.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, Habit>
    {
        public RemoveCommandValidator(DiaryDBContext dbContext) : base(dbContext, ValidationMessages.HabitOnSchedule.GetDescription())
        {
        }
    }
}