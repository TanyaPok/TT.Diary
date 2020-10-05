using TT.Diary.BusinessLogic.Lists.BaseCommands;

namespace TT.Diary.BusinessLogic.Lists.Habits.Commands
{
    public class EditCommand : AbstractEditCommand
    {
        public uint? Amount { set; get; }
    }
}