using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.TimeManagement.Queries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using System.Threading.Tasks;

namespace TT.Diary.WebAPI.Controllers.TimeManagement
{
    public class PlannerController : ApiControllerBase
    {
        public PlannerController(ILogger<PlannerController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Planner>> Get(int userId, DateTime startDate, DateTime finishDate)
        {
            try
            {
                return await QueryAsync<Planner>(new GetPlannerQuery() { UserId = userId, StartDate = startDate, FinishDate = finishDate });
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetPlanner.GetDescription(), ex.Message));
            }
        }
    }
}
