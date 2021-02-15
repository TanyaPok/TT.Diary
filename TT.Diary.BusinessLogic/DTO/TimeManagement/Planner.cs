using System.Collections.Generic;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class Planner
    {
        public IList<ToDo<ScheduleSettings>> ToDoList { get; set; }

        public IList<Habit<ScheduleSettings>> Habits { get; set; }

        public IList<ToDo<ScheduleSettings>> Appointments { get; set; }

        public IList<Wish<ScheduleSettings>> Wishes { get; set; }

        public IList<Note> Notes { get; set; }
    }
}