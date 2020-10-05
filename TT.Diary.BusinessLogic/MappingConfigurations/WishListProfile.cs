using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Lists.WishList.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class WishProfile : Profile
    {
        public WishProfile()
        {
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

            CreateMap<DataAccessLogic.Model.TypeList.Wish, DTO.Lists.Wish>()
                .ForMember(dest => dest.CompletionDate, opt => opt.MapFrom((src, dest) => { return src.Schedule?.CompletionDateUtc; }));

            CreateMap<DataAccessLogic.Model.TypeList.Wish, DTO.Lists.AbstractItem>().As<DTO.Lists.Wish>();
        }
    }
}