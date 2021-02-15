using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseValidation;
using TT.Diary.BusinessLogic.Lists.WishList.Commands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Validation
{
    public class RemoveCommandValidator : AbstractRemoveCommandValidator<RemoveCommand, Wish>
    {
        public RemoveCommandValidator(WishListContainerRepository repository) : base(repository,
            ValidationMessages.IsScheduled.GetDescription())
        {
        }
    }
}