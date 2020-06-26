using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Books.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<DataAccessLogic.Model.Book, ViewModel.Book>();

            CreateMap<DataAccessLogic.Model.Book, ViewModel.IComponent>().As<ViewModel.Book>();

            CreateMap<AddCommand, DataAccessLogic.Model.Book>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Author = WebUtility.HtmlEncode(src.Author);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.Book>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Author = WebUtility.HtmlEncode(src.Author);
                })
                .ForMember(d => d.CreatedDateUtc, o => o.Ignore())
                .ForMember(d => d.Schedule, o => o.Ignore())
                .ForMember(d => d.Rating, o => o.Ignore());
        }
    }
}