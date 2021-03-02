using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class RemoveHandler : AbstractRemoveHandler<RemoveCommand, Category>
    {
        public RemoveHandler(CategoriesContainerRepository repository) : base(repository)
        {
        }
    }
}