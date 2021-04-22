using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public interface IRepository<T> where T : AbstractEntity
    {
        T TryGet(Expression<Func<T, bool>> expression);

        T Get<TProperty>(Expression<Func<T, bool>> condition, Expression<Func<T, TProperty>> expression)
            where TProperty : AbstractEntity;

        Task AddAsync(T item, CancellationToken cancellationToken);
        void Remove(T item);
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}