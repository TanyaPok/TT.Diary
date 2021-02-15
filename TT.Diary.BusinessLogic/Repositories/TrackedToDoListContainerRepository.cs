using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class TrackedToDoListContainerRepository : AbstractBaseTrackedContainerRepository<ToDo>
    {
        private readonly DiaryDBContext _dbContext;

        public TrackedToDoListContainerRepository(DiaryDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IList<DTO.Lists.ToDo<ScheduleSettings>> GetTrackedList(int userId, DateTime startDate,
            DateTime finishDate)
        {
            var toDoList = (from u in _dbContext.Users
                join c in _dbContext.Categories on u.Id equals c.UserId
                join t in _dbContext.ToDoList on c.Id equals t.CategoryId
                join s in _dbContext.Schedules on t.ScheduleId equals s.Id
                    into result
                from r in result.DefaultIfEmpty()
                where u.Id == userId
                      && ((r.ScheduledStartDateTimeUtc.Date >= startDate &&
                           r.ScheduledStartDateTimeUtc.Date <= finishDate)
                          || (r.ScheduledCompletionDateUtc.HasValue &&
                              r.ScheduledCompletionDateUtc.Value.Date >= startDate &&
                              r.ScheduledCompletionDateUtc.Value.Date <= finishDate)
                          || (r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= startDate &&
                              r.CompletionDateUtc.Value.Date <= finishDate)
                          || (r.ScheduledStartDateTimeUtc.Date < startDate
                              && (!r.ScheduledCompletionDateUtc.HasValue ||
                                  r.ScheduledCompletionDateUtc.Value.Date >= finishDate ||
                                  r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= finishDate)))
                select new DTO.Lists.ToDo<ScheduleSettings>
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
                            from tr in _dbContext.Trackers
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
                                Significance = (tr.ScheduledDateUtc.Date < tr.DateTimeUtc.Date) ? WithDelay : InTime
                            }).ToList()
                    }
                }).ToList();
            return toDoList;
        }
    }
}