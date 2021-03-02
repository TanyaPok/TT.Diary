using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Queries
{
    public class GetItemsHandler : AbstractGetItemsBaseHandler<GetItemsQuery, ToDo, ToDo<ScheduleSettingsSummary>>
    {
        public GetItemsHandler(ToDoListContainerRepository repository, IMapper mapper) : base(repository, mapper, c => c.ToDoList)
        {
        }
    }
}