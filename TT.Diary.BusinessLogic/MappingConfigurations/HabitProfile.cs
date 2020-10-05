using System.Net;
using AutoMapper;
using TT.Diary.BusinessLogic.Lists.Habits.Commands;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class HabitProfile : Profile
    {
        public HabitProfile()
        {
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

            CreateMap<DataAccessLogic.Model.TypeList.Habit, DTO.Lists.Habit>()
                .ForMember(dest => dest.CompletionDate, opt => opt.MapFrom((src, dest) => { return src.Schedule?.CompletionDateUtc; }));

            CreateMap<DataAccessLogic.Model.TypeList.Habit, DTO.Lists.Habit>().As<DTO.Lists.Habit>();
        }
    }
}