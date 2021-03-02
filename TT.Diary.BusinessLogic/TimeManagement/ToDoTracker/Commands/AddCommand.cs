using System;
using TT.Diary.BusinessLogic.BaseCommands;

namespace TT.Diary.BusinessLogic.TimeManagement.ToDoTracker.Commands
{
    public class AddCommand : AbstractAddTrackerCommand
    {
        public DateTime ScheduledDate { set; get; }
    }
}