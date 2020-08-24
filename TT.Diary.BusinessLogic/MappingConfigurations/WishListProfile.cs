using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.WishList.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class WishProfile : Profile
    {
        public WishProfile()
        {
            CreateMap<DataAccessLogic.Model.TypeList.Wish, DTO.Wish>();

            CreateMap<DataAccessLogic.Model.TypeList.Wish, DTO.AbstractComponent>().As<DTO.Wish>();

            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.Wish>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Author = WebUtility.HtmlEncode(src.Author);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.Wish>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Author = WebUtility.HtmlEncode(src.Author);
                })
                .ForMember(d => d.Schedule, o => o.Ignore());
        }
    }
}