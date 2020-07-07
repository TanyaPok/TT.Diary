using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.Habits.Commands
{
    public class AddCommand : AbstractCommand
    {
        public int? Amount { set; get; }
    }
}