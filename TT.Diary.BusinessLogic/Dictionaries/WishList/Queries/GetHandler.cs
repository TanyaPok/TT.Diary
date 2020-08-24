using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Queries
{
    public class GetHandler : GetBaseHandler<DTO.Wish, DataAccessLogic.Model.TypeList.Wish, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}