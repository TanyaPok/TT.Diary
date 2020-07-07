using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.BaseValidation;
using TT.Diary.BusinessLogic.Dictionaries.WishList.Commands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, Wish>
    {
        public RemoveCommandValidator(DiaryDBContext dbContext) : base(dbContext, ValidationMessages.WishOnSchedule.GetDescription())
        {
        }
    }
}