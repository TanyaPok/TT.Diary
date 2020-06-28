using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Queries
{
    public class GetHandler : GetBaseHandler<ViewModel.Wish, DataAccessLogic.Model.Wish, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}