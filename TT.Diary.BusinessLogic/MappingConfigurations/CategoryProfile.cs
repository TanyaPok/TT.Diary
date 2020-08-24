using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;

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

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.AbstractComponent>().As<DTO.Category>();

            CreateMap<DataAccessLogic.Model.AbstractComponent, DTO.AbstractComponent>().As<DTO.Category>();

            CreateMap<DataAccessLogic.Model.TypeList.Category, DTO.Category>();
        }
    }
}