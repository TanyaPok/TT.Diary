using MediatR;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands
{
    public class EditCommand : AbstractCommand, IRequest
    {
        public int Id { set; get; }
        public string Author { set; get; }
    }
}