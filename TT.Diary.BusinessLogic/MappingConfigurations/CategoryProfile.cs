using System.Linq;
using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Lists.Categories.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.Category>()
                .BeforeMap((src, dest) => src.Description = WebUtility.HtmlEncode(src.Description));

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.Category>()
                .BeforeMap((src, dest) => src.Description = WebUtility.HtmlEncode(src.Description));

            var comparer = new PriorityComparer();
            CreateMap<DataAccessLogic.Model.TypeList.Category,
                    DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => src.WishList.OrderBy(t=>t.Priority, comparer)));

            CreateMap<DataAccessLogic.Model.TypeList.Category,
                    DTO.Lists.Category<DTO.Lists.ToDo<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => src.ToDoList.OrderBy(t=>t.Priority, comparer)));

            CreateMap<DataAccessLogic.Model.TypeList.Category,
                    DTO.Lists.Category<DTO.Lists.Habit<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => src.Habits.OrderBy(t=>t.Priority, comparer)));
            
            CreateMap<DataAccessLogic.Model.TypeList.Category,
                    DTO.Lists.Category<DTO.Lists.Appointment<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => src.Appointments.OrderBy(t=>t.Priority, comparer)));

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.Lists.Category<DTO.Lists.Note>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => src.Notes));
        }
    }
}