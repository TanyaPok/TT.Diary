using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitTracker.Commands
{
    public class AddHandler : AbstractAddTrackerHandler<AddCommand, Habit>
    {
        public AddHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
