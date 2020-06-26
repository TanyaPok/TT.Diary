using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.Queries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.Books.Queries
{
    public class GetHandler : GetBaseHandler<ViewModel.Book, DataAccessLogic.Model.Book, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}