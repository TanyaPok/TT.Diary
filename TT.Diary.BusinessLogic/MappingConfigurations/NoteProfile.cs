using AutoMapper;
using System.Net;
using TT.Diary.BusinessLogic.Lists.Notes.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.Note>()
                .BeforeMap((src, dest) => { src.Description = WebUtility.HtmlEncode(src.Description); })
                .ForMember(dest => dest.ScheduleDateUtc, opt => opt.MapFrom((src, dest) => src.ScheduleDate));

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.Note>()
                .BeforeMap((src, dest) => { src.Description = WebUtility.HtmlEncode(src.Description); })
                .ForMember(dest => dest.ScheduleDateUtc, opt => opt.MapFrom((src, dest) => src.ScheduleDate));

            CreateMap<DataAccessLogic.Model.TypeList.Note, DTO.Lists.Note>()
                .ForMember(dest => dest.ScheduleDate, opt => opt.MapFrom((src, dest) => src.ScheduleDateUtc));

            CreateMap<DataAccessLogic.Model.TypeList.Note, DTO.Lists.AbstractCategoryItem>().As<DTO.Lists.Note>();
        }
    }
}