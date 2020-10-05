﻿using System;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class Appointment : AbstractComponent
    {
        public Schedule Shedule { get; set; }

        public ScheduleSettings ScheduleSettings { get; set; }

        public DateTime DateTimeUtc { set; get; }

        public int Progress { set; get; }
    }
}
