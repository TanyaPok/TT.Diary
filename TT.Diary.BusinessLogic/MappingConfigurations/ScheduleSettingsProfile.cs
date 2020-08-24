using AutoMapper;
using TT.Diary.BusinessLogic.Schedule.Settings.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class ScheduleSettingsProfile : Profile
    {
        public ScheduleSettingsProfile()
        {
            CreateMap<SetCommand, DataAccessLogic.Model.TimeManagement.ScheduleSettings>()
                .ForMember(d => d.StartDateUtc, o => o.MapFrom(s => s.StartDate))
                .ForMember(d => d.FinishDateUtc, o => o.MapFrom(s => s.FinishDate));

            CreateMap<DataAccessLogic.Model.TimeManagement.ScheduleSettings, DTO.TimeManagement.ScheduleSettings>();
        }
    }
}
