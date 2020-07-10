using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.ToDoList.Commands
{
    public class EditCommand : AbstractEditCommand
    {
        public string Title { get; set; }
    }
}
