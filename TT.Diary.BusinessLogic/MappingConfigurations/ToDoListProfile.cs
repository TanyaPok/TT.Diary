using AutoMapper;
using System.Net;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Lists.ToDoList.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.ToDo>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.ToDo>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                })
                .ForMember(d => d.Schedule, o => o.Ignore());

            CreateMap<DataAccessLogic.Model.TypeList.ToDo, DTO.Lists.ToDo<ScheduleSettingsSummary>>()
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom((src, dest) => { return src.Schedule; }))
                .ForMember(dest => dest.IsTracked, opt => opt.MapFrom((src, dest) => { return src.Trackers.Count > 0; }));

            CreateMap<DataAccessLogic.Model.TypeList.ToDo, DTO.Lists.AbstractScheduledItem<ScheduleSettingsSummary>>().As<DTO.Lists.ToDo<ScheduleSettingsSummary>>();
        }
    }
}