using MediatR;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class EditCommand : AbstractCommand, IRequest
    {
        public int Id { set; get; }
        public int OldCategoryId { set; get; }
    }
}