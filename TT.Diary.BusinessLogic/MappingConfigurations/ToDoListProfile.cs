using AutoMapper;
using System.Net;
using TT.Diary.BusinessLogic.Dictionaries.ToDoList.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<DataAccessLogic.Model.TypeList.ToDo, DTO.ToDo>();

            CreateMap<DataAccessLogic.Model.TypeList.ToDo, DTO.AbstractComponent>().As<DTO.ToDo>();

            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.ToDo>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.ToDo>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                })
                .ForMember(d => d.Schedule, o => o.Ignore());
        }
    }
}