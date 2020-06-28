using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<DataAccessLogic.Model.Category, ViewModel.Category>();

            CreateMap<DataAccessLogic.Model.Category, ViewModel.IComponent>().As<ViewModel.Category>();

            CreateMap<DataAccessLogic.Model.Category, ViewModel.Category>()
                .ForMember(dest => dest.Children, opt => opt.MapFrom((src, dest, t, context) =>
                    {
                        var categories = context.Mapper
                            .Map<IList<DataAccessLogic.Model.Category>, IList<ViewModel.IComponent>>(src.Subcategories ?? new List<DataAccessLogic.Model.Category>());
                        var books = context.Mapper
                            .Map<IList<DataAccessLogic.Model.Wish>, IList<ViewModel.IComponent>>(src.Wishes ?? new List<DataAccessLogic.Model.Wish>());
                        return categories.Union(books);
                    }))
                .PreserveReferences()
                .ReverseMap();

            CreateMap<AddCommand, DataAccessLogic.Model.Category>()
                .BeforeMap((src, dest) => src.Description = WebUtility.HtmlEncode(src.Description));

            CreateMap<EditCommand, DataAccessLogic.Model.Category>()
                .BeforeMap((src, dest) => src.Description = WebUtility.HtmlEncode(src.Description));
        }
    }
}