using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetHandler : GetBaseHandler<DTO.Category, DataAccessLogic.Model.TypeList.Category, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}