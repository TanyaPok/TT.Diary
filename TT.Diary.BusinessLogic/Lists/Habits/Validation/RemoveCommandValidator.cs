using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseValidation;
using TT.Diary.BusinessLogic.Lists.Habits.Commands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, Habit>
    {
        public RemoveCommandValidator(HabitsContainerRepository repository) : base(repository,
            ValidationMessages.IsScheduled.GetDescription())
        {
        }
    }
}