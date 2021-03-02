using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TT.Diary.BusinessLogic.MappingConfigurations;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.WebAPI
{
    public static class Extensions
    {
        public static void ConfigureDiaryAutomapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ToDoListProfile());
                mc.AddProfile(new HabitProfile());
                mc.AddProfile(new WishProfile());
                mc.AddProfile(new NoteProfile());
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new ScheduleSettingsProfile());
                mc.AddProfile(new TrackerProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureDiaryRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<CategoriesContainerRepository>();
            services.AddScoped<HabitsContainerRepository>();
            services.AddScoped<ToDoListContainerRepository>();
            services.AddScoped<WishListContainerRepository>();
            services.AddScoped<NotesContainerRepository>();
            services.AddScoped<ScheduleSettingsRepository>();
            services.AddScoped<TrackedHabitsContainerRepository>();
            services.AddScoped<TrackedToDoListContainerRepository>();
            services.AddScoped<TrackedAppointmentsContainerRepository>();
        }
    }
}