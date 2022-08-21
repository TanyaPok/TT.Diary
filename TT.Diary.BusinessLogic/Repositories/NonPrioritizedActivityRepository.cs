using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class NonPrioritizedActivityRepository
    {
        private readonly DiaryDBContext _dbContext;

        public NonPrioritizedActivityRepository(DiaryDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<NonPrioritizedActivity> GetList(int userId)
        {
            var result = Get(_dbContext.ToDoList, userId, "to-do")
                .Union(Get(_dbContext.Appointments, userId, "appointment"))
                .Union(Get(_dbContext.WishList, userId, "wish"))
                .Union(Get(_dbContext.Habits, userId, "habit"))
                .ToList();
            return result;
        }

        private IEnumerable<NonPrioritizedActivity> Get<T>(IQueryable<T> data, int userId, string type)
            where T : AbstractItem
        {
            return data
                .Include(t => t.Category)
                .Where(t => t.Schedule == null && t.Priority == Priority.None && t.Category.UserId == userId)
                .Select(t => new NonPrioritizedActivity()
                {
                    Id = t.Id,
                    Description = t.Description,
                    Category = t.Category.Description,
                    Type = type
                }).AsEnumerable();
        }
    }
}