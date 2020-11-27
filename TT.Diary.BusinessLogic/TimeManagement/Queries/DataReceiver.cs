using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    internal class DataReceiver
    {
        private readonly double WITH_DELAY = 0.5;
        private readonly double IN_TIME = 1.0;

        internal List<ToDo> GetToDoList(DiaryDBContext context, int userId, DateTime startDate, DateTime finishDate)
        {
            var toDoList = (from u in context.Users
                            join c in context.Categories on u.Id equals c.UserId
                            join t in context.ToDoList on c.Id equals t.CategoryId
                            join s in context.Schedules on t.ScheduleId equals s.Id
                            into result
                            from r in result.DefaultIfEmpty()
                            where u.Id == userId
                                && ((r.ScheduledStartDateTimeUtc.Date >= startDate && r.ScheduledStartDateTimeUtc.Date <= finishDate)
                                    || (r.ScheduledCompletionDateUtc.HasValue && r.ScheduledCompletionDateUtc.Value.Date >= startDate && r.ScheduledCompletionDateUtc.Value.Date <= finishDate)
                                    || (r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= startDate && r.CompletionDateUtc.Value.Date <= finishDate)
                                    || (r.ScheduledStartDateTimeUtc.Date < startDate
                                        && (!r.ScheduledCompletionDateUtc.HasValue || r.ScheduledCompletionDateUtc.Value.Date >= finishDate || r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= finishDate)))
                            select new ToDo
                            {
                                Id = t.Id,
                                Description = t.Description,
                                Schedule = new ScheduleSettings()
                                {
                                    ScheduledStartDateTime = r.ScheduledStartDateTimeUtc,
                                    ScheduledCompletionDate = r.ScheduledCompletionDateUtc,
                                    CompletionDate = r.CompletionDateUtc,
                                    Repeat = r.Repeat,
                                    Every = r.Every,
                                    Months = r.Months,
                                    Weekdays = r.Weekdays,
                                    DaysAmount = r.DaysAmount
                                },
                                Trackers = (
                                    from tr in context.Trackers
                                    where t.Id == tr.ToDoId
                                        && (tr.ScheduledDateUtc.Date >= startDate && tr.ScheduledDateUtc.Date <= finishDate
                                            || tr.DateTimeUtc.Date >= startDate && tr.DateTimeUtc.Date <= finishDate)
                                    select new Tracker()
                                    {
                                        ScheduledDate = tr.ScheduledDateUtc,
                                        DateTime = tr.DateTimeUtc,
                                        Progress = tr.Progress,
                                        Value = tr.Value,
                                        Significance = (tr.ScheduledDateUtc.Date < tr.DateTimeUtc.Date) ? WITH_DELAY : IN_TIME
                                    }).ToList()
                            }).ToList();
            return toDoList;
        }

        internal List<Appointment> GetAppointments(DiaryDBContext context, int userId, DateTime startDate, DateTime finishDate)
        {
            var appointments = (from u in context.Users
                                join c in context.Categories on u.Id equals c.UserId
                                join t in context.Appointments on c.Id equals t.CategoryId
                                join s in context.Schedules on t.ScheduleId equals s.Id
                                into result
                                from r in result.DefaultIfEmpty()
                                where u.Id == userId
                                    && ((r.ScheduledStartDateTimeUtc.Date >= startDate && r.ScheduledStartDateTimeUtc.Date <= finishDate)
                                        || (r.ScheduledCompletionDateUtc.HasValue && r.ScheduledCompletionDateUtc.Value.Date >= startDate && r.ScheduledCompletionDateUtc.Value.Date <= finishDate)
                                        || (r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= startDate && r.CompletionDateUtc.Value.Date <= finishDate)
                                        || (r.ScheduledStartDateTimeUtc.Date < startDate
                                            && (!r.ScheduledCompletionDateUtc.HasValue || r.ScheduledCompletionDateUtc.Value.Date >= finishDate || r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= finishDate)))
                                select new Appointment
                                {
                                    Id = t.Id,
                                    Description = t.Description,
                                    Schedule = new ScheduleSettings()
                                    {
                                        ScheduledStartDateTime = r.ScheduledStartDateTimeUtc,
                                        ScheduledCompletionDate = r.ScheduledCompletionDateUtc,
                                        CompletionDate = r.CompletionDateUtc,
                                        Repeat = r.Repeat,
                                        Every = r.Every,
                                        Months = r.Months,
                                        Weekdays = r.Weekdays,
                                        DaysAmount = r.DaysAmount
                                    },
                                    Trackers = (
                                        from tr in context.Trackers
                                        where t.Id == tr.AppointmentId
                                            && (tr.ScheduledDateUtc.Date >= startDate && tr.ScheduledDateUtc.Date <= finishDate
                                                || tr.DateTimeUtc.Date >= startDate && tr.DateTimeUtc.Date <= finishDate)
                                        select new Tracker()
                                        {
                                            ScheduledDate = tr.ScheduledDateUtc,
                                            DateTime = tr.DateTimeUtc,
                                            Progress = tr.Progress,
                                            Value = tr.Value,
                                            Significance = (tr.ScheduledDateUtc.Date < tr.DateTimeUtc.Date) ? WITH_DELAY : IN_TIME
                                        }).ToList()
                                }).ToList();
            return appointments;
        }
    }
}
