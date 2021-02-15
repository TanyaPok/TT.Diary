using FluentValidation;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.BaseCommands;
using System;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseValidation
{
    public abstract class AbstractScheduledCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : AbstractScheduledCommand
    {
        protected AbstractScheduledCommandValidator()
        {
            RuleFor(r => r).Custom((command, context) =>
            {
                if (command.OwnerId < 1)
                {
                    context.AddFailure(ValidationMessages.InvalidOwnerScheduleSettingsId.GetDescription());
                }

                if (command.ScheduledStartDateTime.Date <= DateTime.MinValue)
                {
                    context.AddFailure(ValidationMessages.NotSetDateTime.GetDescription());
                }

                if (!Enum.IsDefined(typeof(Repeat), command.Repeat))
                {
                    context.AddFailure(string.Format(ValidationMessages.EnumOutOfRange.GetDescription(), nameof(Repeat),
                        command.Repeat));
                }

                if (command.Repeat == Repeat.Yearly && !Enum.IsDefined(typeof(Months), command.Months))
                {
                    var checkSum = (int) command.Months;

                    foreach (Months item in Enum.GetValues(command.Months.GetType()))
                    {
                        if (command.Months.HasFlag(item))
                        {
                            checkSum -= (int) item;
                        }
                    }

                    if (checkSum != 0)
                    {
                        context.AddFailure(string.Format(ValidationMessages.EnumOutOfRange.GetDescription(),
                            nameof(Months), command.Months));
                    }
                }

                if (command.Repeat == Repeat.Weekly)
                {
                    var checkSum = (int) command.Weekdays;

                    foreach (Weekdays item in Enum.GetValues(command.Weekdays.GetType()))
                    {
                        if (command.Weekdays.HasFlag(item))
                        {
                            checkSum -= (int) item;
                        }
                    }

                    if (checkSum != 0)
                    {
                        context.AddFailure(string.Format(ValidationMessages.EnumOutOfRange.GetDescription(),
                            nameof(Weekdays), command.Weekdays));
                    }
                }

                if (command.Repeat != Repeat.None && command.Every < 1)
                {
                    context.AddFailure(ValidationMessages.InvalidPeriodsGap.GetDescription());
                }
            });
        }
    }
}