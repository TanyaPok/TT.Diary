using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.TimeManagement.AppointmentPriority.Commands;

namespace TT.Diary.WebAPI.Controllers.TimeManagement.Appointments
{
    public class AppointmentPriorityController : ApiControllerBase
    {
        public AppointmentPriorityController(ILogger<ApiControllerBase> logger, IMediator mediator) : base(logger,
            mediator)
        {
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> EditAsync([FromBody] SetCommand query)
        {
            try
            {
                return Ok(await CommandAsync<bool>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE,
                    ErrorMessages.SavePriority.GetDescription(), ex.Message));
            }
        }
    }
}