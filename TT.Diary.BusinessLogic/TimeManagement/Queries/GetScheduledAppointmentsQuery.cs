using MediatR;
using System.Collections.Generic;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetScheduledAppointmentsQuery : AbstractQuery, IRequest<List<DailyScheduledAppointments>>
    {
    }
}