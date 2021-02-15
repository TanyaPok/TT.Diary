using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Habits.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, Habit, Category>
    {
        public EditHandler(HabitsContainerRepository repository, IMapper mapper) : base(
            repository, mapper,
            c => c.Habits)
        {
        }
    }
}