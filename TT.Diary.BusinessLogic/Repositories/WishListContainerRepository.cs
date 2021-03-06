﻿using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class WishListContainerRepository : AbstractBaseScheduledItemRepository<Wish>
    {
        private readonly DiaryDBContext _dbContext;

        public WishListContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.WishList, c => c.WishList.Where(s => s.Schedule == null))
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IList<DTO.Lists.Wish<ScheduleSettings>> GetScheduledList(int userId, DateTime startDate,
            DateTime finishDate)
        {
            var wishList = (from u in _dbContext.Users
                join c in _dbContext.Categories on u.Id equals c.UserId
                join h in _dbContext.WishList on c.Id equals h.CategoryId
                join s in _dbContext.Schedules on h.ScheduleId equals s.Id
                    into result
                from r in result.DefaultIfEmpty()
                where u.Id == userId
                      && ((r.ScheduledStartDateTimeUtc.Date >= startDate &&
                           r.ScheduledStartDateTimeUtc.Date <= finishDate)
                          || (r.CompletionDateUtc.HasValue && r.CompletionDateUtc.Value.Date >= startDate &&
                              r.CompletionDateUtc.Value.Date <= finishDate)
                          || (r.ScheduledStartDateTimeUtc.Date < startDate
                              && (!r.CompletionDateUtc.HasValue ||
                                   r.CompletionDateUtc.Value.Date >= finishDate)))
                select new DTO.Lists.Wish<ScheduleSettings>
                {
                    Id = h.Id,
                    Description = h.Description,
                    Author = h.Author,
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
                        DaysAmount = r.DaysAmount
                    }
                }).ToList();
            return wishList;
        }
    }
}