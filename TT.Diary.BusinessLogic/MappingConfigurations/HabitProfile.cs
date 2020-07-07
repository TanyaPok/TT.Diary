using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Habits.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class HabitProfile : Profile
    {
        public HabitProfile()
        {
            CreateMap<DataAccessLogic.Model.Habit, ViewModel.Habit>();

            CreateMap<DataAccessLogic.Model.Habit, ViewModel.AbstractComponent>().As<ViewModel.Habit>();

            CreateMap<AddCommand, DataAccessLogic.Model.Habit>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                });

            CreateMap<EditCommand, DataAccessLogic.Model.Habit>()
                .BeforeMap((src, dest) =>
                {
                    src.Description = WebUtility.HtmlEncode(src.Description);
                })
                .ForMember(d => d.Schedule, o => o.Ignore());
        }
    }
}