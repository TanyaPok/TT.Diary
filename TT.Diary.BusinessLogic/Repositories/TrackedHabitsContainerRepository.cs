using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class TrackedHabitsContainerRepository : AbstractBaseTrackedContainerRepository<Habit>
    {
        private readonly DiaryDBContext _dbContext;

        public TrackedHabitsContainerRepository(DiaryDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IList<Habit<ScheduleSettings>> GetTrackedList(int userId, DateTime startDate, DateTime finishDate)
        {
            var habits = (from u in _dbContext.Users
                join c in _dbContext.Categories on u.Id equals c.UserId
                join h in _dbContext.Habits on c.Id equals h.CategoryId
                join s in _dbContext.Schedules on h.ScheduleId equals s.Id
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
                            from tr in _dbContext.Trackers
                            where h.Id == tr.HabitId && tr.ScheduledDateUtc.Date >= startDate &&
                                  tr.ScheduledDateUtc.Date <= finishDate
                            select new DTO.TimeManagement.Tracker()
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
            return habits;
        }
    }
}