using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.Repositories.Common
{
    public abstract class AbstractBaseTrackedContainerRepository<T> : AbstractBaseRepository<Tracker>,
        IContainerRepository<T, Tracker>
        where T : TrackedAbstractItem
    {
        private readonly DiaryDBContext _dbContext;
        protected readonly double WithDelay = 0.5;
        protected readonly double InTime = 1.0;


        protected AbstractBaseTrackedContainerRepository(DiaryDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public T GetFirstLevel(int id, Expression<Func<T, IEnumerable<Tracker>>> expression)
        {
            return _dbContext.Set<T>().Include(expression).AsEnumerable().Single(e => e.Id == id);
        }

        public virtual void AddTo(T parent, Tracker child)
        {
            parent.Trackers.Add(child);
        }

        public virtual void RemoveFrom(T parent, Tracker child)
        {
            parent.Trackers.Remove(child);
        }

        public virtual void RemoveFrom(T parent, IList<Tracker> children)
        {
            _dbContext.RemoveRange(children);
        }
    }
}