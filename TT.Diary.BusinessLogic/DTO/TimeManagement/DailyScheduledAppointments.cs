using System;
using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class DailyScheduledAppointments
    {
        public DateTime Date { get; set; }

        public List<Tuple<DateTime, string>> ScheduledAppointments { get; set; }

        public List<Tuple<DateTime, string>> DoneAppointments { get; set; }
    }
}