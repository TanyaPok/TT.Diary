using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public interface IContainerRepository<T, TChild> where T : AbstractComponent where TChild : AbstractEntity
    {
        T GetFirstLevel(int id, Expression<Func<T, IEnumerable<TChild>>> expression);
        Task<int> AddToAsync(T parent, TChild child, CancellationToken cancellationToken);
        Task<int> RemoveFromAsync(T parent, TChild child, CancellationToken cancellationToken);
        Task<int> RemoveFromAsync(T parent, IList<TChild> children, CancellationToken cancellationToken);
    }
}