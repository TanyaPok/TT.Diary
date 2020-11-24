using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Lists.Habits.Queries
{
    public class GetHandler : GetBaseHandler<DTO.Lists.Habit, DataAccessLogic.Model.TypeList.Habit, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}