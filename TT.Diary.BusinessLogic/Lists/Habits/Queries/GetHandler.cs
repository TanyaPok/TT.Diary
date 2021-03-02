using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetHandler : AbstractGetBaseHandler<DTO.Lists.Habit<ScheduleSettingsSummary>, Habit, GetQuery>
    {
        public GetHandler(HabitsContainerRepository repository, IMapper mapper) : base(
            repository, mapper)
        {
        }
    }
}