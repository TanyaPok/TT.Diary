﻿using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.Appointments.Queries;

namespace TT.Diary.BusinessLogic.Lists.Appointments.Validation
{
    public class GetQueryValidator : AbstractValidator<GetQuery>
    {
        public GetQueryValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());
        }
    }
}