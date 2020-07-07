using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.Habits.Commands
{
    public class EditCommand : AbstractEditCommand
    {
        public int? Amount { set; get; }
    }
}