using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class Planner
    {
        public IList<ToDo> ToDoList { get; set; }

        public IList<Appointment> Appointments { get; set; }

        public IList<Household> HouseholdList { get; set; }

        public IList<HabitSchedule> Habits { get; set; }

        public IList<Lists.Note> Notes { get; set; }
    }
}
