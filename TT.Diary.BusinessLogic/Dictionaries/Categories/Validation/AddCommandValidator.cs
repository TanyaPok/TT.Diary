using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.BaseValidation;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Validation
{
    public class AddCommandValidator : AbstractCommandValidator<AddCommand>
    {
    }
}