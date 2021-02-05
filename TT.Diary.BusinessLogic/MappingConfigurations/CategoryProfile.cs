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

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.Lists.Category<DTO.Lists.Wish<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => { return src.WishList; }));

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.Lists.Category<DTO.Lists.ToDo<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => { return src.ToDoList; }));

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.Lists.Category<DTO.Lists.Habit<ScheduleSettingsSummary>>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => { return src.Habits; }));

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.Lists.Category<DTO.Lists.Note>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest) => { return src.Notes; }));
        }
    }
}