using MediatR;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPlannerQuery : AbstractQuery, IRequest<Planner>
    {
    }
}
