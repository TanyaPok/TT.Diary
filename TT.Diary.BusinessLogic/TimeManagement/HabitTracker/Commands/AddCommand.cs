using System;
using TT.Diary.BusinessLogic.BaseCommands;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitTracker.Commands
{
    public class AddCommand : AbstractAddTrackerCommand
    {
        public DateTime ScheduledDate { set; get; }
    }
}