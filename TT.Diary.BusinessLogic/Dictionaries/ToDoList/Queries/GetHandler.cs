using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Dictionaries.ToDoList.Queries
{
    public class GetHandler : GetBaseHandler<ViewModel.ToDo, DataAccessLogic.Model.ToDo, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
