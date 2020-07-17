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
    public class DiaryDBContext : DbContext
    {
        private readonly IDataSettings _dataSettings;

        public DiaryDBContext(DbContextOptions<DiaryDBContext> options, IDataSettings dataSettings) : base(options)
        {
            _dataSettings = dataSettings ?? throw new ArgumentNullException(nameof(dataSettings));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUTC(modelBuilder);
            ConfigurePublicUtilities(modelBuilder);

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

        private void ConfigurePublicUtilities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new { Id = _dataSettings.PublicUtilitiesCategoryId, Description = "Public Utilities" });
            modelBuilder.Entity<Category>().HasData(new { Id = _dataSettings.MeterReadingCategoryId, Description = "Meter reading" });
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