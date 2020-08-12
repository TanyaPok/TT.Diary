using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.DataAccessLogic
{
    //TODO: review all operations
    public class DiaryDBContext : DbContext
    {
        private DbSet<User> Users { get; set; }

        public DiaryDBContext(DbContextOptions<DiaryDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUTC(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public T TryGet<T>(Expression<Func<T, bool>> expression) where T : AbstractEntity
        {
            return Set<T>().FirstOrDefault(expression);
        }

        public void ConfigureUserWorkspaceAsync(User user)
        {
            user.Categories.Add(new Category { Description = "To-do list" });
            user.Categories.Add(new Category { Description = "Wish list" });
            user.Categories.Add(new Category { Description = "Habits" });
            user.Categories.Add(new Category { Description = "Notes" });
            user.Categories.Add(new Category { Description = "Public Utilities" });
            user.Categories.Add(new Category { Description = "Meter reading" });
        }

        public T Get<T>(int id) where T : AbstractEntity
        {
            return Set<T>().Single(e => e.Id == id);
        }

        public T Get<T, P>(int id, Expression<Func<T, IEnumerable<P>>> expression)
            where T : AbstractEntity
            where P : AbstractEntity
        {
            return Set<T>().Include(expression).Single(e => e.Id == id);
        }

        public T Get<T, P>(int id, Expression<Func<T, P>> expression)
            where T : AbstractEntity
            where P : AbstractEntity
        {
            return Set<T>().Include(expression).Single(e => e.Id == id);
        }

        public T GetRecursively<T>(int id, Expression<Func<T, IEnumerable<T>>> expression)
            where T : AbstractEntity
        {
            return GetRecursively<T, T>(id, expression);
        }

        public T GetRecursively<T, P>(int id,
            Expression<Func<T, IEnumerable<T>>> expression,
            Expression<Func<T, IEnumerable<P>>>[] expressions = null)
                where T : AbstractEntity
                where P : AbstractEntity
        {
            return GetRecursively<T, P>((int?)id, expression, expressions).Single();
        }

        public List<T> GetRecursively<T, P>(Expression<Func<T, IEnumerable<T>>> expression,
            Expression<Func<T, IEnumerable<P>>>[] expressions = null)
                where T : AbstractEntity
                where P : AbstractEntity
        {
            return GetRecursively<T, P>(null, expression, expressions).ToList();
        }

        private IEnumerable<T> GetRecursively<T, P>(int? id, Expression<Func<T, IEnumerable<T>>> expression,
            Expression<Func<T, IEnumerable<P>>>[] expressions = null)
                where T : AbstractEntity
                where P : AbstractEntity
        {
            if (expressions != null && expressions.Count() > 0)
            {
                var query = Set<T>().Include(expressions[0]);

                for (var i = 1; i < expressions.Count(); i++)
                {
                    query = query.Include(expressions[i]);
                }

                if (id == null)
                    return query.Include(expression).AsEnumerable();
                else
                    return query.Include(expression).AsEnumerable().Where(c => c.Id == id.Value);
            }

            if (id == null)
                return Set<T>().Include(expression).AsEnumerable();
            else
                return Set<T>().Include(expression).AsEnumerable().Where(c => c.Id == id.Value);
        }

        private void ConfigureUTC(ModelBuilder modelBuilder)
        {
            var utcConverter = new ValueConverter<DateTime, DateTime>(
                outValue => outValue,
                inValue => DateTime.SpecifyKind(inValue, DateTimeKind.Utc)
            );

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                     .Where(p => p.ClrType == typeof(DateTime) && p.Name.EndsWith("Utc"));
                foreach (var property in properties)
                {
                    property.SetValueConverter(utcConverter);
                }
            }
        }
    }
}