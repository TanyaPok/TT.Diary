using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class Planner
    {
        public IList<ToDo> ToDoList { get; set; }

        public IList<Habit> Habits { get; set; }

        public IList<Lists.Note> Notes { get; set; }

        public int ToDoRootCategoryId { get; set; }
    }
}
