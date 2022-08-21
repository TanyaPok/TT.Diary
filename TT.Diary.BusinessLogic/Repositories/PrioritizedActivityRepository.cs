using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class PrioritizedActivityRepository
    {
        private readonly DiaryDBContext _dbContext;

        public PrioritizedActivityRepository(DiaryDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<PrioritizedActivity> GetList(int userId, DateTime startDate, DateTime finishDate)
        {
            var result = Get(_dbContext.ToDoList, startDate, finishDate, userId, "to-do")
                .Union(Get(_dbContext.Appointments, startDate, finishDate, userId, "appointment"))
                .Union(Get(_dbContext.WishList, startDate, finishDate, userId, "wish"))
                .Union(Get(_dbContext.Habits, startDate, finishDate, userId, "habit"))
                .ToList();
            return result;
        }

        private IEnumerable<PrioritizedActivity> Get<T>(IQueryable<T> data, DateTime startDate, DateTime finishDate,
            int userId, string type)
            where T : AbstractItem
        {
            return data
                .Include(t => t.Category)
                .Where(t => t.Schedule == null && t.Priority != Priority.None && t.Category.UserId == userId &&
                            t.PriorityModifyDateTimeUtc.Date >= startDate.Date && t.PriorityModifyDateTimeUtc.Date <= finishDate.Date)
                .Select(t => new PrioritizedActivity()
                {
                    Id = t.Id,
                    Description = t.Description,
                    Category = t.Category.Description,
                    Type = type,
                    Priority = t.Priority
                }).AsEnumerable();
        }
    }
}