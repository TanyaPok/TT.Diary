using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Queries
{
    public class GetHandler : GetBaseHandler<DTO.Lists.ToDo, DataAccessLogic.Model.TypeList.ToDo, GetQuery>
    {
        public GetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
