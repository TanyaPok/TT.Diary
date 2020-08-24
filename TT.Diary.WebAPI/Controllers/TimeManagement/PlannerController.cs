using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.TimeManagement.Queries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

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
        public ActionResult<Planner> Get(int userId, DateTime startDate, DateTime finishDate)
        {
            try
            {
                return Query<Planner>(new GetPlannerQuery() { UserId = userId, StartDate = startDate, FinishDate = finishDate });
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetScheduler.GetDescription(), ex.Message));
            }
        }
    }
}
