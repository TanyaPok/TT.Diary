using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class WishProfile : Profile
    {
        public WishProfile()
        {
            CreateMap<DataAccessLogic.Model.Wish, ViewModel.Wish>();

            CreateMap<DataAccessLogic.Model.Wish, ViewModel.IComponent>().As<ViewModel.Wish>();

            CreateMap<AddCommand, DataAccessLogic.Model.Wish>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Author = WebUtility.HtmlEncode(src.Author);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.Wish>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Author = WebUtility.HtmlEncode(src.Author);
                })
                .ForMember(d => d.Schedule, o => o.Ignore())
                .ForMember(d => d.Rating, o => o.Ignore());
        }
    }
}