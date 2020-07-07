using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class EditCommand : AbstractCommand
    {
        public int Id { set; get; }
        public int OldCategoryId { set; get; }
    }
}