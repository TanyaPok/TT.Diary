using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Habits.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, Habit, Category>
    {
        public EditHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper, c => c.Habits)
        {
        }
    }
}