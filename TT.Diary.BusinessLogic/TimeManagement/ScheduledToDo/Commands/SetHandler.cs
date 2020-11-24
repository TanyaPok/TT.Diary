using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.ScheduledToDo.Commands
{
    public class SetHandler : AbstractSetScheduledHandler<SetCommand, ToDo>
    {
        public SetHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
