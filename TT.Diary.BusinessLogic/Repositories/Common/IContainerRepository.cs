using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public interface IContainerRepository<T, TChild> where T : AbstractComponent where TChild : AbstractEntity
    {
        T GetFirstLevel(int id, Expression<Func<T, IEnumerable<TChild>>> expression);
        void AddTo(T parent, TChild child);
        void RemoveFrom(T parent, TChild child);
        void RemoveFrom(T parent, IList<TChild> children);
    }
}