using TT.Diary.BusinessLogic.Lists.BaseCommands;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class AddCommand : AbstractCommand
    {
        public int UserId { get; set; }
    }
}