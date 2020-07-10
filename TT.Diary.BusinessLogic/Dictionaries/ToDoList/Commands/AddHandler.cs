using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.ToDoList.Commands
{
    public class AddHandler : AbstractAddHandler<AddCommand, ToDo, Category>
    {
        public AddHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper, c => c.ToDoList)
        {
        }
    }
}
