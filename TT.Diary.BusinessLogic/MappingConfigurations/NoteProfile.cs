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
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                });

            CreateMap<DataAccessLogic.Model.TypeList.Note, DTO.Lists.Note>();

            CreateMap<DataAccessLogic.Model.TypeList.Note, DTO.Lists.Note>().As<DTO.Lists.Note>();
        }
    }
}