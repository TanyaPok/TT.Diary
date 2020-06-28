using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.DataAccessLogic
{
    public partial class DiaryDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<ToDo> ToDoList { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Tracker> Trackers { get; set; }

        public DiaryDBContext(DbContextOptions<DiaryDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        public async Task<T> GetAsync<T>(int id, CancellationToken cancellationToken)
            where T : AbstractEntity
        {
            return await this.Set<T>().SingleAsync(b => b.Id == id, cancellationToken);
        }

        public T Get<T, P>(int id, Expression<Func<T, IEnumerable<P>>> expression)
            where T : AbstractEntity
            where P : AbstractEntity
        {
            var entity = Find<T>(id);
            Entry(entity).Collection(expression).Load();
            return entity;
        }

        public T Get<T, P>(int id, Expression<Func<T, P>> expression)
            where T : AbstractEntity
            where P : AbstractEntity
        {
            var entity = Find<T>(id);
            Entry(entity).Reference(expression).Load();
            return entity;
        }

        public T GetRecursively<T>(int id, Expression<Func<T, IEnumerable<T>>> recursiveExpression)
            where T : AbstractEntity
        {
            return this.Set<T>().Include(recursiveExpression).AsEnumerable().Single(c => c.Id == id);
        }

        public T GetRecursively<T, P>(int id,
                Expression<Func<T, IEnumerable<T>>> recursiveExpression,
                Expression<Func<T, IEnumerable<P>>> expression)
            where T : AbstractEntity
            where P : AbstractEntity
        {
            return this.Set<T>()
                .Include(expression)
                .AsQueryable()
                .Include(recursiveExpression)
                    .ThenInclude(expression)
                .AsEnumerable()
                .Single(c => c.Id == id);
        }
    }
}