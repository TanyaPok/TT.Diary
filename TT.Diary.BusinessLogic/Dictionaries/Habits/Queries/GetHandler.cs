using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.Habits.Queries
{
    public class GetHandler : GetBaseHandler<DTO.Habit, DataAccessLogic.Model.TypeList.Habit, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}