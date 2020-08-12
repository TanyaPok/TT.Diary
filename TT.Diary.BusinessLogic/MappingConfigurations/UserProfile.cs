using AutoMapper;
using System.Net;
using TT.Diary.BusinessLogic.Users.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SetCommand, DataAccessLogic.Model.User>()
                .BeforeMap((src, dest) =>
                {
                    src.Given_Name = WebUtility.HtmlEncode(src.Given_Name);
                    dest.Name = src.Given_Name;
                })
                .BeforeMap((src, dest) => src.Sub = WebUtility.HtmlEncode(src.Sub));
        }
    }
}
