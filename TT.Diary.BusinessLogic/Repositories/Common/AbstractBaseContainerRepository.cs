using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public abstract class AbstractBaseContainerRepository<TChild> : AbstractBaseRepository<TChild>,
        IContainerRepository<Category, TChild>
        where TChild : AbstractEntity
    {
        private readonly DiaryDBContext _dbContext;
        private readonly string _titleList;

        protected AbstractBaseContainerRepository(DiaryDBContext dbContext, string titleList) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _titleList = titleList ?? throw new ArgumentNullException(nameof(titleList));
        }

        public virtual void AddTo(Category parent, TChild child)
        {
            parent.Add(child);
        }

        public virtual void RemoveFrom(Category parent, TChild child)
        {
            parent.Remove(child);
        }

        public virtual void RemoveFrom(Category parent, IList<TChild> children)
        {
            foreach (var child in children.ToArray())
            {
                parent.Remove(child);
            }
        }

        public virtual Category GetFirstLevel(int id, Expression<Func<Category, IEnumerable<TChild>>> expression)
        {
            return _dbContext.Set<Category>().Include(expression).AsEnumerable().Single(e => e.Id == id);
        }

        public virtual Category GetAllLevels(int userId, Expression<Func<Category, IEnumerable<TChild>>> expression)
        {
            return _dbContext.Set<Category>().Include(expression).AsEnumerable().SingleOrDefault(e =>
                e.UserId == userId && e.Description == _titleList && e.ParentId == null);
        }
    }
}