using AutoMapper;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class ScheduleSettingsProfile : Profile
    {
        public ScheduleSettingsProfile()
        {
            CreateMap<TimeManagement.HabitSchedule.Commands.SetCommand, DataAccessLogic.Model.TimeManagement.ScheduleSettings>()
                .ForMember(d => d.ScheduledStartDateTimeUtc, o => o.MapFrom(s => s.ScheduledStartDateTime))
                .ForMember(d => d.ScheduledCompletionDateUtc, o => o.MapFrom(s => s.ScheduledCompletionDate))
                .ForMember(d => d.CompletionDateUtc, o => o.MapFrom(s => s.CompletionDate));

            CreateMap<DataAccessLogic.Model.TimeManagement.ScheduleSettings, DTO.TimeManagement.ScheduleSettingsSummary>()
                .ForMember(d => d.ScheduledStartDateTime, o => o.MapFrom(s => s.ScheduledStartDateTimeUtc))
                .ForMember(d => d.ScheduledCompletionDate, o => o.MapFrom(s => s.ScheduledCompletionDateUtc))
                .ForMember(d => d.CompletionDate, o => o.MapFrom(s => s.CompletionDateUtc));
        }
    }
}
