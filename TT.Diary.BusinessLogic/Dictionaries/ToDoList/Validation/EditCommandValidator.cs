using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.BaseValidation;
using TT.Diary.BusinessLogic.Dictionaries.ToDoList.Commands;

namespace TT.Diary.BusinessLogic.Dictionaries.ToDoList.Validation
{
    public class EditCommandValidator : AbstractCommandValidator<EditCommand>
    {
        public EditCommandValidator() : base()
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());
        }
    }
}
