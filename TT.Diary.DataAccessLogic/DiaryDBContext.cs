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
    public partial class DiaryDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Wish> WishList { get; set; }
        public DbSet<ToDo> ToDoList { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Tracker> Trackers { get; set; }

        public DiaryDBContext(DbContextOptions<DiaryDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            base.OnModelCreating(modelBuilder);
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
            if (expressions != null && expressions.Count() > 0)
            {
                var query = Set<T>().Include(expressions[0]);

                for (var i = 1; i < expressions.Count(); i++)
                {
                    query = query.Include(expressions[i]);
                }

                return query.Include(expression).AsEnumerable().Single(c => c.Id == id);
            }

            return Set<T>().Include(expression).AsEnumerable().Single(c => c.Id == id);
        }
    }
}