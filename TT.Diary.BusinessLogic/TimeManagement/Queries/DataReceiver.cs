using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    internal class DataReceiver
    {
        private readonly double WITH_DELAY = 0.5;

        private readonly double IN_TIME = 1.0;

        internal IList<ToDo<ScheduleSettings>> GetToDoList(DiaryDBContext context, int userId, DateTime startDate, DateTime finishDate)
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
                            select new ToDo<ScheduleSettings>
                            {
                                Id = t.Id,
                                Description = t.Description,
                                Schedule = new ScheduleSettings
                                {
                                    Id = r.Id,
                                    ScheduledStartDateTime = r.ScheduledStartDateTimeUtc,
                                    ScheduledCompletionDate = r.ScheduledCompletionDateUtc,
                                    CompletionDate = r.CompletionDateUtc,
                                    Repeat = r.Repeat,
                                    Every = r.Every,
                                    Months = r.Months,
                                    Weekdays = r.Weekdays,
                                    DaysAmount = r.DaysAmount,
                                    Trackers = (
                                        from tr in context.Trackers
                                        where t.Id == tr.ToDoId
                                            && (tr.ScheduledDateUtc.Date >= startDate && tr.ScheduledDateUtc.Date <= finishDate
                                                || tr.DateTimeUtc.Date >= startDate && tr.DateTimeUtc.Date <= finishDate)
                                        select new Tracker()
                                        {
                                            Id = tr.Id,
                                            ScheduledDate = tr.ScheduledDateUtc,
                                            DateTime = tr.DateTimeUtc,
                                            Progress = tr.Progress,
                                            Value = tr.Value,
                                            Significance = (tr.ScheduledDateUtc.Date < tr.DateTimeUtc.Date) ? WITH_DELAY : IN_TIME
                                        }).ToList()
                                }
                            }).ToList();
            return toDoList;
        }

        internal IList<Habit<ScheduleSettings>> GetHabits(DiaryDBContext context, int userId, DateTime startDate, DateTime finishDate)
        {
            var habits = (from u in context.Users
                          join c in context.Categories on u.Id equals c.UserId
                          join h in context.Habits on c.Id equals h.CategoryId
                          join s in context.Schedules on h.ScheduleId equals s.Id
                          into result
                          from r in result.DefaultIfEmpty()
                          where u.Id == userId
                              && ((r.ScheduledStartDateTimeUtc.Date >= startDate && r.ScheduledStartDateTimeUtc.Date <= finishDate)
                                  || (r.ScheduledCompletionDateUtc.HasValue && r.ScheduledCompletionDateUtc.Value.Date >= startDate && r.ScheduledCompletionDateUtc.Value.Date <= finishDate)
                                  || (r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= startDate && r.CompletionDateUtc.Value.Date <= finishDate)
                                  || (r.ScheduledStartDateTimeUtc.Date < startDate
                                      && (!r.ScheduledCompletionDateUtc.HasValue || r.ScheduledCompletionDateUtc.Value.Date >= finishDate || r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= finishDate)))
                          select new Habit<ScheduleSettings>
                          {
                              Id = h.Id,
                              Description = h.Description,
                              Amount = h.Amount,
                              Schedule = new ScheduleSettings
                              {
                                  Id = r.Id,
                                  ScheduledStartDateTime = r.ScheduledStartDateTimeUtc,
                                  ScheduledCompletionDate = r.ScheduledCompletionDateUtc,
                                  CompletionDate = r.CompletionDateUtc,
                                  Repeat = r.Repeat,
                                  Every = r.Every,
                                  Months = r.Months,
                                  Weekdays = r.Weekdays,
                                  DaysAmount = r.DaysAmount,
                                  Trackers = (
                                    from tr in context.Trackers
                                    where h.Id == tr.HabitId && tr.ScheduledDateUtc.Date >= startDate && tr.ScheduledDateUtc.Date <= finishDate
                                    select new Tracker()
                                    {
                                        Id = tr.Id,
                                        ScheduledDate = tr.ScheduledDateUtc,
                                        DateTime = tr.DateTimeUtc,
                                        Progress = tr.Progress,
                                        Value = tr.Value,
                                        Significance = (tr.ScheduledDateUtc.Date < tr.DateTimeUtc.Date) ? WITH_DELAY : IN_TIME
                                    }).ToList()
                              }
                          }).ToList();
            return habits;
        }

        internal IList<Note> GetNotes(DiaryDBContext context, int userId, DateTime startDate, DateTime finishDate)
        {
            return (from u in context.Users
                    join c in context.Categories on u.Id equals c.UserId
                    join n in context.Notes on c.Id equals n.CategoryId
                    into result
                    from r in result.DefaultIfEmpty()
                    where u.Id == userId && (r.ScheduleDateUtc.Date >= startDate && r.ScheduleDateUtc.Date <= finishDate)
                    select new Note
                    {
                        Id = r.Id,
                        Description = r.Description,
                        ScheduleDate = r.ScheduleDateUtc
                    }).ToList();
        }

        internal IList<ToDo<ScheduleSettings>> GetAppointments(DiaryDBContext context, int userId, DateTime startDate, DateTime finishDate)
        {
            var appointments = (from u in context.Users
                                join c in context.Categories on u.Id equals c.UserId
                                join a in context.Appointments on c.Id equals a.CategoryId
                                join s in context.Schedules on a.ScheduleId equals s.Id
                                into result
                                from r in result.DefaultIfEmpty()
                                where u.Id == userId
                                    && ((r.ScheduledStartDateTimeUtc.Date >= startDate && r.ScheduledStartDateTimeUtc.Date <= finishDate)
                                        || (r.ScheduledCompletionDateUtc.HasValue && r.ScheduledCompletionDateUtc.Value.Date >= startDate && r.ScheduledCompletionDateUtc.Value.Date <= finishDate)
                                        || (r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= startDate && r.CompletionDateUtc.Value.Date <= finishDate)
                                        || (r.ScheduledStartDateTimeUtc.Date < startDate
                                            && (!r.ScheduledCompletionDateUtc.HasValue || r.ScheduledCompletionDateUtc.Value.Date >= finishDate || r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= finishDate)))
                                select new ToDo<ScheduleSettings>
                                {
                                    Id = a.Id,
                                    Description = a.Description,
                                    Schedule = new ScheduleSettings
                                    {
                                        Id = r.Id,
                                        ScheduledStartDateTime = r.ScheduledStartDateTimeUtc,
                                        ScheduledCompletionDate = r.ScheduledCompletionDateUtc,
                                        CompletionDate = r.CompletionDateUtc,
                                        Repeat = r.Repeat,
                                        Every = r.Every,
                                        Months = r.Months,
                                        Weekdays = r.Weekdays,
                                        DaysAmount = r.DaysAmount,
                                        Trackers = (
                                            from tr in context.Trackers
                                            where a.Id == tr.AppointmentId
                                                && (tr.ScheduledDateUtc.Date >= startDate && tr.ScheduledDateUtc.Date <= finishDate
                                                    || tr.DateTimeUtc.Date >= startDate && tr.DateTimeUtc.Date <= finishDate)
                                            select new Tracker()
                                            {
                                                Id = tr.Id,
                                                ScheduledDate = tr.ScheduledDateUtc,
                                                DateTime = tr.DateTimeUtc,
                                                Progress = tr.Progress,
                                                Value = tr.Value,
                                                Significance = (tr.ScheduledDateUtc.Date < tr.DateTimeUtc.Date) ? WITH_DELAY : IN_TIME
                                            }).ToList()
                                    }
                                }).ToList();
            return appointments;
        }
    }
}
