﻿using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseValidation;
using TT.Diary.BusinessLogic.Lists.ToDoList.Commands;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Validation
{
    public class EditCommandValidator : AbstractCommandValidator<EditCommand>
    {
        public EditCommandValidator() : base()
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage(ValidationMessages.InvalidId.GetDescription());
        }
    }
}