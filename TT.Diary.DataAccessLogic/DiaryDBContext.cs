using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Serilog;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.DataAccessLogic
{
    public class DiaryDBContext : DbContext
    {
        private readonly string _connectionString;
        
        private readonly bool _isDevelopment;

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ToDo> ToDoList { get; set; }

        public DbSet<Habit> Habits { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Wish> WishList { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<ScheduleSettings> Schedules { get; set; }

        public DbSet<Tracker> Trackers { get; set; }

        public DiaryDBContext(string connectionString, bool isDevelopment)
        {
            _connectionString = connectionString;
            _isDevelopment = isDevelopment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
                           {
                               builder.AddDebug();
                               builder.AddSerilog();
                           });
            
            optionsBuilder.UseSqlite(_connectionString,
                b => b.MigrationsAssembly(typeof(DiaryDBContext).Assembly.FullName));

            if (_isDevelopment)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }

            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .AddInterceptors(new BaseDbCommandInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationships(modelBuilder);
            ConfigureUTC(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOne(c => c.User).WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId);
            //forbid to change user for category
            modelBuilder.Entity<Category>().Property(c => c.UserId).Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            modelBuilder.Entity<Category>().HasOne(c => c.Parent).WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.ParentId);

            modelBuilder.Entity<ToDo>().HasOne(t => t.Category).WithMany(c => c.ToDoList)
                .HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<ToDo>().HasOne(t => t.Schedule).WithOne(s => s.Owner as ToDo)
                .HasForeignKey<ToDo>(t => t.ScheduleId);

            modelBuilder.Entity<Appointment>().HasOne(t => t.Category).WithMany(c => c.Appointments)
                .HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Appointment>().HasOne(t => t.Schedule).WithOne(s => s.Owner as Appointment)
                .HasForeignKey<Appointment>(t => t.ScheduleId);

            modelBuilder.Entity<Habit>().HasOne(t => t.Category).WithMany(c => c.Habits)
                .HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Habit>().HasOne(t => t.Schedule).WithOne(s => s.Owner as Habit)
                .HasForeignKey<Habit>(t => t.ScheduleId);

            modelBuilder.Entity<Note>().HasOne(t => t.Category).WithMany(c => c.Notes).HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Tracker>().HasOne(t => t.Owner as ToDo).WithMany(o => o.Trackers)
                .HasForeignKey(t => t.ToDoId);
            modelBuilder.Entity<Tracker>().HasOne(t => t.Owner as Habit).WithMany(o => o.Trackers)
                .HasForeignKey(t => t.HabitId);
            modelBuilder.Entity<Tracker>().HasOne(t => t.Owner as Appointment).WithMany(o => o.Trackers)
                .HasForeignKey(t => t.AppointmentId);
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