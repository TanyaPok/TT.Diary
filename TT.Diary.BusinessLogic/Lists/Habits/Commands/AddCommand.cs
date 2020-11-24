using TT.Diary.BusinessLogic.BaseCommands;

namespace TT.Diary.BusinessLogic.Lists.Habits.Commands
{
    public class AddCommand : AbstractCommand
    {
        public uint? Amount { set; get; }
    }
}