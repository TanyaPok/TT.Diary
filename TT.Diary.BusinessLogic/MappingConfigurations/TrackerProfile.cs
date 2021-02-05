using AutoMapper;
using TT.Diary.BusinessLogic.TimeManagement.HabitTracker.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class TrackerProfile : Profile
    {
        public TrackerProfile()
        {
            CreateMap<AddCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.ScheduledDateUtc, o => o.MapFrom(s => s.ScheduledDate))
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<EditCommand, DataAccessLogic.Model.TimeManagement.Tracker>()
                .ForMember(d => d.DateTimeUtc, o => o.MapFrom(s => s.DateTime));

            CreateMap<DataAccessLogic.Model.TimeManagement.Tracker, DTO.TimeManagement.Tracker>()
                .ForMember(d => d.DateTime, o => o.MapFrom(s => s.DateTimeUtc))
                .ForMember(d => d.ScheduledDate, o => o.MapFrom(s => s.ScheduledDateUtc));
        }
    }
}
