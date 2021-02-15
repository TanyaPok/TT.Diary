using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class HabitsContainerRepository : AbstractBaseContainerRepository<Category, Habit>
    {
        private readonly DiaryDBContext _dbContext;
        private readonly string _titleList;

        public HabitsContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.Habits)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _titleList = categoryTitleList.Habits ?? throw new ArgumentNullException(nameof(categoryTitleList.Habits));
        }

        public override Category GetAllLevels(int userId, Expression<Func<Category, IEnumerable<Habit>>> expression)
        {
            return _dbContext.Set<Category>().Include(expression).ThenInclude(c => c.Schedule).Include(expression)
                .ThenInclude(c => c.Trackers).Include(c => c.Subcategories).AsEnumerable().SingleOrDefault(e =>
                    e.UserId == userId && e.Description == _titleList && e.ParentId == null);
        }

        public Category GetAllUnscheduledLevels(int userId)
        {
            return _dbContext.Set<Category>().Include(c => c.Habits.Where(s => s.Schedule == null))
                .Include(c => c.Subcategories).AsEnumerable()
                .SingleOrDefault(e => e.UserId == userId && e.Description == _titleList && e.ParentId == null);
        }
    }
}