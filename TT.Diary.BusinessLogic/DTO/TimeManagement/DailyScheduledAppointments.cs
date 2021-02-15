using System;
using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class DailyScheduledAppointments
    {
        public DateTime Date { get; set; }

        public List<string> ScheduledAppointmentsDescriptions { get; set; }

        public List<string> DoneAppointmentsDescriptions { get; set; }
    }
}