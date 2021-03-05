using AutoMapper;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class TrackerProfile : Profile
    {
        public TrackerProfile()
        {
            CreateMap<TimeManagement.HabitTracker.Commands.AddCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.ScheduledDateUtc, o => o.MapFrom(s => s.ScheduledDate))
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<TimeManagement.HabitTracker.Commands.EditCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<TimeManagement.ToDoTracker.Commands.AddCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.ScheduledDateUtc, o => o.MapFrom(s => s.ScheduledDate))
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<TimeManagement.ToDoTracker.Commands.EditCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));
            
            CreateMap<TimeManagement.AppointmentTracker.Commands.AddCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.ScheduledDateUtc, o => o.MapFrom(s => s.ScheduledDate))
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<TimeManagement.AppointmentTracker.Commands.EditCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<DataAccessLogic.Model.TimeManagement.Tracker, DTO.TimeManagement.Tracker>()
                .ForMember(d => d.DateTime, o => o.MapFrom(s => s.DateTimeUtc))
                .ForMember(d => d.ScheduledDate, o => o.MapFrom(s => s.ScheduledDateUtc));
        }
    }
}