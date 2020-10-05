using TT.Diary.BusinessLogic.Lists.BaseCommands;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class EditCommand : AbstractCommand
    {
        public int Id { set; get; }

        public int OldCategoryId { set; get; }
    }
}