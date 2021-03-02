using AutoMapper;
using TT.Diary.DataAccessLogic.Model.TypeList;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetItemsHandler : AbstractGetItemsBaseHandler<GetItemsQuery, Habit, Habit<ScheduleSettingsSummary>>
    {
        public GetItemsHandler(HabitsContainerRepository repository, IMapper mapper) : base(repository, mapper, c => c.Habits)
        {
        }
    }
}