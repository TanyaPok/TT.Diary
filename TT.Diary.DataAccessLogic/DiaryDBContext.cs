using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.DataAccessLogic
{
    public class DiaryDBContext : DbContext
    {
        private readonly ICategoryTitleList _categoryTitleList;

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ToDo> ToDoList { get; set; }

        public DbSet<Habit> Habits { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Wish> WishList { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<ScheduleSettings> Schedules { get; set; }

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

        public void ConfigureUserWorkspace(User user)
        {
            user.Categories.Add(new Category { Description = _categoryTitleList.ToDoList });
            user.Categories.Add(new Category { Description = _categoryTitleList.Appointments });
            user.Categories.Add(new Category { Description = _categoryTitleList.Habits });
            user.Categories.Add(new Category { Description = _categoryTitleList.PublicUtilities });
            user.Categories.Add(new Category { Description = _categoryTitleList.WishList });
            user.Categories.Add(new Category { Description = _categoryTitleList.Notes });
        }

        public T TryGet<T>(Expression<Func<T, bool>> expression) where T : AbstractEntity
        {
            return Set<T>().FirstOrDefault(expression);
        }

        public Category GetWishList(int userId)
        {
            return GetRecursively<Category, Wish>(userId, _categoryTitleList.WishList, c => c.Subcategories, c => c.WishList);
        }

        public Category GetRootToDoList(int userId)
        {
            return Set<Category>().AsEnumerable().SingleOrDefault(e => e.UserId == userId && e.Description == _categoryTitleList.ToDoList && e.ParentId == null);
        }

        public Category GetToDoList(int userId)
        {
            return GetRecursively<Category, ToDo>(userId, _categoryTitleList.ToDoList, c => c.Subcategories, c => c.ToDoList);
        }

        public Category GetHabits(int userId)
        {
            return GetRecursively<Category, Habit>(userId, _categoryTitleList.Habits, c => c.Subcategories, c => c.Habits);
        }

        public Category GetNotes(int userId)
        {
            return Set<Category>().Include(c => c.Notes).AsEnumerable().SingleOrDefault(e => e.UserId == userId && e.Description == _categoryTitleList.Notes && e.ParentId == null);
        }

        public T GetTrackedItem<T>(int ownerId)
            where T : TrackedAbstractItem
        {
            return Set<T>().Include(t => t.Schedule).Include(t => t.Trackers).Single(t => t.Id == ownerId);
        }

        public T Get<T, P>(int id, Expression<Func<T, P>> expression)
           where T : AbstractEntity
           where P : AbstractEntity
        {
            return Set<T>().Include(expression).Single(e => e.Id == id);
        }

        public T Get<T, P>(int id, Expression<Func<T, IEnumerable<P>>> expression)
            where T : AbstractEntity
            where P : AbstractEntity
        {
            return Set<T>().Include(expression).AsEnumerable().Single(e => e.Id == id);
        }

        public bool IsRootCategory(int id)
        {
            var category = TryGet<Category>(e => e.Id == id);
            return (category.Description == _categoryTitleList.WishList
                || category.Description == _categoryTitleList.ToDoList
                || category.Description == _categoryTitleList.Habits
                || category.Description == _categoryTitleList.Appointments
                || category.Description == _categoryTitleList.PublicUtilities
                || category.Description == _categoryTitleList.Notes)
                && category.ParentId == null;
        }

        private T GetRecursively<T, P>(int userId, string categoryDescription, Expression<Func<T, IEnumerable<T>>> recursiveExpression, Expression<Func<T, IEnumerable<P>>> expression)
            where T : Category
            where P : AbstractItem
        {
            return Set<T>().Include(expression).ThenInclude(c => c.Schedule).Include(recursiveExpression).AsEnumerable().SingleOrDefault(e => e.UserId == userId && e.Description == categoryDescription && e.ParentId == null);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOne(c => c.User).WithMany(u => u.Categories).HasForeignKey(c => c.UserId);
            //forbid to change user for category
            modelBuilder.Entity<Category>().Property(c => c.UserId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            modelBuilder.Entity<Category>().HasOne(c => c.Parent).WithMany(c => c.Subcategories).HasForeignKey(c => c.ParentId);

            modelBuilder.Entity<ToDo>().HasOne(t => t.Category).WithMany(c => c.ToDoList).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<ToDo>().HasOne(t => t.Schedule).WithOne(s => s.Owner as ToDo).HasForeignKey<ToDo>(t => t.ScheduleId);

            modelBuilder.Entity<Appointment>().HasOne(t => t.Category).WithMany(c => c.Appointments).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Appointment>().HasOne(t => t.Schedule).WithOne(s => s.Owner as Appointment).HasForeignKey<Appointment>(t => t.ScheduleId);

            modelBuilder.Entity<Habit>().HasOne(t => t.Category).WithMany(c => c.Habits).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Habit>().HasOne(t => t.Schedule).WithOne(s => s.Owner as Habit).HasForeignKey<Habit>(t => t.ScheduleId);

            modelBuilder.Entity<Note>().HasOne(t => t.Category).WithMany(c => c.Notes).HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Tracker>().HasOne(t => t.Owner as ToDo).WithMany(o => o.Trackers).HasForeignKey(t => t.ToDoId);
            modelBuilder.Entity<Tracker>().HasOne(t => t.Owner as Habit).WithMany(o => o.Trackers).HasForeignKey(t => t.HabitId);
            modelBuilder.Entity<Tracker>().HasOne(t => t.Owner as Appointment).WithMany(o => o.Trackers).HasForeignKey(t => t.AppointmentId);
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