using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Lists.Appointments.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class AppointmentsProfile : Profile
    {
        public AppointmentsProfile()
        {
            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.Appointment>()
                .BeforeMap((src, dest) => { src.Description = WebUtility.HtmlEncode(src.Description); });

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.Appointment>()
                .BeforeMap((src, dest) => { src.Description = WebUtility.HtmlEncode(src.Description); })
                .ForMember(d => d.Schedule, o => o.Ignore());

            CreateMap<DataAccessLogic.Model.TypeList.Appointment, DTO.Lists.Appointment<ScheduleSettingsSummary>>()
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom((src, dest) => src.Schedule))
                .ForMember(dest => dest.IsTracked,
                    opt => opt.MapFrom((src, dest) => src.Trackers?.Count > 0));

            CreateMap<DataAccessLogic.Model.TypeList.Appointment, DTO.Lists.AbstractScheduledItem<ScheduleSettingsSummary>>()
                .As<DTO.Lists.Appointment<ScheduleSettingsSummary>>();
        }
    }
}