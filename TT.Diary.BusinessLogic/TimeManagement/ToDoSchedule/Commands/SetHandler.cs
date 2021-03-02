using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ToDoSchedule.Commands
{
    public class SetHandler : AbstractSetScheduledHandler<SetCommand, ToDo>
    {
        public SetHandler(ToDoListContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}