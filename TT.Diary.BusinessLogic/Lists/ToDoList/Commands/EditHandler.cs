using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.ToDoList.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, ToDo>
    {
        public EditHandler(ToDoListContainerRepository repository, IMapper mapper) : base(repository, mapper,
            c => c.ToDoList)
        {
        }
    }
}