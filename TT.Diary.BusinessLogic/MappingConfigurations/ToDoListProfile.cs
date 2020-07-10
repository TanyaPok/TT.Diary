using AutoMapper;
using System.Net;
using TT.Diary.BusinessLogic.Dictionaries.ToDoList.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<DataAccessLogic.Model.ToDo, ViewModel.ToDo>();

            CreateMap<DataAccessLogic.Model.ToDo, ViewModel.AbstractComponent>().As<ViewModel.ToDo>();

            CreateMap<AddCommand, DataAccessLogic.Model.ToDo>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Title = WebUtility.HtmlEncode(src.Title ?? string.Empty);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.ToDo>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                    src.Title = WebUtility.HtmlEncode(src.Title ?? string.Empty);
                })
                .ForMember(d => d.Schedule, o => o.Ignore());
        }
    }
}