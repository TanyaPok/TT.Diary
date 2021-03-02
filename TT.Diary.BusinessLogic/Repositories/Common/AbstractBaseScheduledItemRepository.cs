using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public abstract class AbstractBaseScheduledItemRepository<TChild> : AbstractBaseContainerRepository<TChild>
        where TChild : AbstractItem
    {
        private readonly DiaryDBContext _dbContext;
        private readonly string _titleList;
        private readonly Expression<Func<Category, IEnumerable<TChild>>> _expression;

        protected AbstractBaseScheduledItemRepository(DiaryDBContext dbContext, string titleList, Expression<Func<Category, IEnumerable<TChild>>> expression) 
            : base(dbContext, titleList)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _titleList = titleList ?? throw new ArgumentNullException(nameof(titleList));
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public override Category GetAllLevels(int userId, Expression<Func<Category, IEnumerable<TChild>>> expression)
        {
            return _dbContext.Set<Category>().Include(expression).ThenInclude(c => c.Schedule).Include(expression)
                .Include(c => c.Subcategories).AsEnumerable().SingleOrDefault(e =>
                    e.UserId == userId && e.Description == _titleList && e.ParentId == null);
        }

        public Category GetAllUnscheduledLevels(int userId)
        {
            return _dbContext.Set<Category>().Include(_expression)
                .Include(c => c.Subcategories).AsEnumerable()
                .SingleOrDefault(e => e.UserId == userId && e.Description == _titleList && e.ParentId == null);
        }
    }
}