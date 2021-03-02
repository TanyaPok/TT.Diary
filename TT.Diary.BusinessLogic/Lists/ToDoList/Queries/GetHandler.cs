using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Queries
{
    public class GetHandler : AbstractGetBaseHandler<DTO.Lists.ToDo<ScheduleSettingsSummary>,
        DataAccessLogic.Model.TypeList.ToDo, GetQuery>
    {
        public GetHandler(ToDoListContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}