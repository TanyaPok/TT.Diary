using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.TimeManagement.Queries;

namespace TT.Diary.WebAPI.Controllers.TimeManagement
{
    public class PrioritizedActivitiesController : ApiControllerBase
    {
        public PrioritizedActivitiesController(ILogger<ApiControllerBase> logger, IMediator mediator) : base(logger,
            mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<PrioritizedActivity>>> Get(int userId, DateTime startDate,
            DateTime finishDate)
        {
            try
            {
                return await QueryAsync<List<PrioritizedActivity>>(new GetPrioritizedActivityQuery()
                    {UserId = userId, StartDate = startDate, FinishDate = finishDate});
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE,
                    ErrorMessages.PrioritizedActivity.GetDescription(), ex.Message));
            }
        }
    }
}