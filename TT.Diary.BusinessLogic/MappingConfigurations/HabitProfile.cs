using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Habits.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class HabitProfile : Profile
    {
        public HabitProfile()
        {
            CreateMap<DataAccessLogic.Model.TypeList.Habit, DTO.Habit>();

            CreateMap<DataAccessLogic.Model.TypeList.Habit, DTO.AbstractComponent>().As<DTO.Habit>();

            CreateMap<AddCommand, DataAccessLogic.Model.TypeList.Habit>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.TypeList.Habit>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                })
                .ForMember(d => d.Schedule, o => o.Ignore());
        }
    }
}