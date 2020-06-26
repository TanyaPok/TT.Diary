using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Queries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetHandler : GetBaseHandler<ViewModel.Category, DataAccessLogic.Model.Category, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}