using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public abstract class AbstractBaseRepository<T> : IRepository<T> where T : AbstractEntity
    {
        private readonly DiaryDBContext _dbContext;

        protected AbstractBaseRepository(DiaryDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual T TryGet(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual async Task AddAsync(T item, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(item, cancellationToken);
        }

        public virtual void Remove(T item)
        {
            _dbContext.Remove(item);
        }

        public virtual async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual T Get<TProperty>(Expression<Func<T, bool>> condition, Expression<Func<T, TProperty>> expression)
            where TProperty : AbstractEntity
        {
            return _dbContext.Set<T>().Include(expression).Single(condition);
        }
    }
}