using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Commands
{
    public class AddCommand : AbstractCommand
    {
        public string Author { set; get; }
    }
}