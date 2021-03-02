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
    public abstract class AbstractBaseTrackedItemRepository<TChild> : AbstractBaseScheduledItemRepository<TChild>
        where TChild : TrackedAbstractItem
    {
        private readonly DiaryDBContext _dbContext;
        private readonly string _titleList;

        protected AbstractBaseTrackedItemRepository(DiaryDBContext dbContext, string titleList, Expression<Func<Category, IEnumerable<TChild>>> expression) 
            : base(dbContext, titleList, expression)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _titleList = titleList ?? throw new ArgumentNullException(nameof(titleList));
        }

        public override Category GetAllLevels(int userId, Expression<Func<Category, IEnumerable<TChild>>> expression)
        {
            return _dbContext.Set<Category>().Include(expression).ThenInclude(c => c.Schedule).Include(expression)
                .ThenInclude(c => c.Trackers).Include(c => c.Subcategories).AsEnumerable().SingleOrDefault(e =>
                    e.UserId == userId && e.Description == _titleList && e.ParentId == null);
        }
    }
}
