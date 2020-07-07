using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCommand, DataAccessLogic.Model.Category>()
                .BeforeMap((src, dest) => src.Description = WebUtility.HtmlEncode(src.Description));

            CreateMap<EditCommand, DataAccessLogic.Model.Category>()
                .BeforeMap((src, dest) => src.Description = WebUtility.HtmlEncode(src.Description));

            CreateMap<DataAccessLogic.Model.Category, ViewModel.AbstractComponent>().As<ViewModel.Category>();

            CreateMap<DataAccessLogic.Model.Framework.AbstractComponent, ViewModel.AbstractComponent>().As<ViewModel.Category>();

            CreateMap<DataAccessLogic.Model.Category, ViewModel.Category>();
        }
    }
}