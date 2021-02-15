using MediatR;
using System.Collections.Generic;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetAnnualProductivityQuery : AbstractQuery, IRequest<List<DailyProductivity>>
    {
    }
}