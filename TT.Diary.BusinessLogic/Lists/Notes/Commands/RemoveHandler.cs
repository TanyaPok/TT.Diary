using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Note, Category>
    {
        public RemoveHandler(NotesContainerRepository repository) : base(repository)
        {
        }
    }
}