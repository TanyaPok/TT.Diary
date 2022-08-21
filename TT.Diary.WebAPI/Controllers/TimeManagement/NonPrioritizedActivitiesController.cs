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
    public class NonPrioritizedActivitiesController : ApiControllerBase
    {
        public NonPrioritizedActivitiesController(ILogger<ApiControllerBase> logger, IMediator mediator) : base(logger,
            mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<NonPrioritizedActivity>>> Get(int userId)
        {
            try
            {
                return await QueryAsync<List<NonPrioritizedActivity>>(new GetNonPrioritizedActivityQuery() {UserId = userId});
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE,
                    ErrorMessages.NonPrioritizedActivity.GetDescription(), ex.Message));
            }
        }
    }
}