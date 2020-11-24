using TT.Diary.BusinessLogic.BaseCommands;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class EditCommand : AbstractEditCommand
    {
        public int Rating { set; get; }

        public string Author { set; get; }
    }
}