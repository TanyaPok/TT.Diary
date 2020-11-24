using AutoMapper;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class ScheduleSettingsProfile : Profile
    {
        public ScheduleSettingsProfile()
        {
            CreateMap<TimeManagement.ScheduledToDo.Commands.SetCommand, DataAccessLogic.Model.TimeManagement.ScheduleSettings>()
                .ForMember(d => d.ScheduledStartDateTimeUtc, o => o.MapFrom(s => s.ScheduledStartDateTime))
                .ForMember(d => d.ScheduledCompletionDateUtc, o => o.MapFrom(s => s.ScheduledCompletionDate));
        }
    }
}
