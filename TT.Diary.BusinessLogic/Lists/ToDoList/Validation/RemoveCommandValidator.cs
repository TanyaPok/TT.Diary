using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseValidation;
using TT.Diary.BusinessLogic.Lists.ToDoList.Commands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, ToDo>
    {
        public RemoveCommandValidator(ToDoListContainerRepository repository) : base(repository,
            ValidationMessages.IsScheduled.GetDescription())
        {
        }
    }
}