using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitSchedule.Commands
{
    public class SetHandler : AbstractSetScheduledHandler<SetCommand, Habit, Category>
    {
        public SetHandler(HabitsContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}