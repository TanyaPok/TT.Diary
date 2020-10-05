using MediatR;
using System;

namespace TT.Diary.BusinessLogic.Schedule.Settings.Commands
{
    public class SetCommand : IRequest<int>
    {
        public int Repeat { get; set; }

        public int Gap { get; set; }

        public int RepeatEvery { get; set; }

        public int Weekdays { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public int OwnerScheduleSettingsId { get; set; }
    }
}
