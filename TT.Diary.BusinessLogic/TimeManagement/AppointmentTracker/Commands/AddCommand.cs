using System;
using TT.Diary.BusinessLogic.BaseCommands;

namespace TT.Diary.BusinessLogic.TimeManagement.AppointmentTracker.Commands
{
    public class AddCommand : AbstractAddTrackerCommand
    {
        public DateTime ScheduledDate { set; get; }
    }
}