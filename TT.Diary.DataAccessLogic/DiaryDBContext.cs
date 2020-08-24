using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.PublicUtilities;
using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.DataAccessLogic
{
    //TODO: review all operations
    public class DiaryDBContext : DbContext
    {
        private readonly ICategoryTitleList _categoryTitleList;

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDo> ToDoList { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PublicUtility> PublicUtilities { get; set; }
        public DbSet<PublicUtilityTracker> PublicUtilityTrackers { get; set; }
        public DbSet<Wish> WishList { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleSettings> ScheduleSettingsList { get; set; }
        public DbSet<Tracker> Trackers { get; set; }

        public DiaryDBContext(DbContextOptions<DiaryDBContext> options, ICategoryTitleList categoryTitleList) : base(options)
        {
            _categoryTitleList = categoryTitleList ?? throw new ArgumentNullException(nameof(categoryTitleList));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationships(modelBuilder);
            ConfigureUTC(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOne(c => c.User).WithMany(u => u.Categories).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Category>().Property(c => c.UserId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Category>().HasOne(c => c.Parent).WithMany(c => c.Subcategories).HasForeignKey(c => c.ParentId);
            modelBuilder.Entity<Category>().Property(c => c.ParentId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ToDo>().HasOne(t => t.Category).WithMany(c => c.ToDoList).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<ToDo>().Property(t => t.CategoryId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<ToDo>().HasOne(t => t.Schedule).WithOne(s => s.Owner as ToDo).HasForeignKey<ToDo>(t => t.ScheduleId);
            modelBuilder.Entity<ToDo>().Property(c => c.ScheduleId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Appointment>().HasOne(t => t.Category).WithMany(c => c.Appointments).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Appointment>().Property(t => t.CategoryId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Appointment>().HasOne(t => t.Schedule).WithOne(s => s.Owner as Appointment).HasForeignKey<Appointment>(t => t.ScheduleId);
            modelBuilder.Entity<Appointment>().Property(c => c.ScheduleId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Habit>().HasOne(t => t.Category).WithMany(c => c.Habits).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Habit>().Property(t => t.CategoryId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Habit>().HasOne(t => t.Schedule).WithOne(s => s.Owner as Habit).HasForeignKey<Habit>(t => t.ScheduleId);
            modelBuilder.Entity<Habit>().Property(c => c.ScheduleId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }

        #region public methods

        public T TryGet<T>(Expression<Func<T, bool>> expression) where T : AbstractEntity
        {
            return Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetRecursively<T, P>(Expression<Func<T, bool>> mainExpression,
           Expression<Func<T, IEnumerable<T>>> recursiveExpression,
           Expression<Func<T, IEnumerable<P>>> expression)
               where T : AbstractEntity
               where P : AbstractEntity
        {
            return Set<T>().Include(expression).Include(recursiveExpression).AsEnumerable().Where(e => e.Id == 2);
        }

        public void ConfigureUserWorkspaceAsync(User user)
        {
            user.Categories.Add(new Category { Description = _categoryTitleList.ToDoList });
            user.Categories.Add(new Category { Description = _categoryTitleList.Appointments });
            user.Categories.Add(new Category { Description = _categoryTitleList.Habits });
            user.Categories.Add(new Category { Description = _categoryTitleList.PublicUtilities });
            user.Categories.Add(new Category { Description = _categoryTitleList.WishList });
            user.Categories.Add(new Category { Description = _categoryTitleList.Notes });
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
        #endregion

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