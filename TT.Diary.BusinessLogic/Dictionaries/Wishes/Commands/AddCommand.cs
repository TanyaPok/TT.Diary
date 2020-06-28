using MediatR;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands
{
    public class AddCommand : AbstractCommand, IRequest<int>
    {
        public string Author { set; get; }
    }
}