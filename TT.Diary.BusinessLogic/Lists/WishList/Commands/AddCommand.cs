using TT.Diary.BusinessLogic.Lists.BaseCommands;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class AddCommand : AbstractCommand
    {
        public int Rating { set; get; }

        public string Author { set; get; }
    }
}