using AutoMapper;
using TT.Diary.BusinessLogic.Lists.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, Habit, Category>
    {
        public EditHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper, c => c.Habits)
        {
        }
    }
}