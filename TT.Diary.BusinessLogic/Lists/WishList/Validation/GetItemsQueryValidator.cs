using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.WishList.Queries;

namespace TT.Diary.BusinessLogic.Lists.WishList.Validation
{
    public class GetItemsQueryValidator : AbstractValidator<GetItemsQuery>
    {
        public GetItemsQueryValidator()
        {
            RuleFor(r => r.UserId).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());
        }
    }
}