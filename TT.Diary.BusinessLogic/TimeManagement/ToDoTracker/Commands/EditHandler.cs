using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ToDoTracker.Commands
{
    public class EditHandler : AbstractEditTrackerHandler<EditCommand, ToDo>
    {
        public EditHandler(TrackedToDoListContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}