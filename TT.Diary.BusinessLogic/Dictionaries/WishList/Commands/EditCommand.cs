using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Commands
{
    public class EditCommand : AbstractEditCommand
    {
        public int Rating { set; get; }
        public string Author { set; get; }
    }
}