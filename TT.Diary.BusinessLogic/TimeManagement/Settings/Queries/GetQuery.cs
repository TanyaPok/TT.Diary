using MediatR;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.Schedule.Settings.Queries
{
    public class GetQuery : IRequest<ScheduleSettings>
    {
        public int Id { get; set; }
    }
}
