using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.TimeManagement.HabitSchedule.Commands;

namespace TT.Diary.WebAPI.Controllers.TimeManagement.Habits
{
    public class HabitScheduleController : ApiControllerBase
    {
        public HabitScheduleController(ILogger<HabitScheduleController> logger, IMediator mediator) : base(logger,
            mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> SetAsync([FromBody] SetCommand query)
        {
            try
            {
                return Created(nameof(SetAsync), await CommandAsync<int>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE,
                    ErrorMessages.SaveScheduleSettings.GetDescription(), ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> RemoveAsync(int id)
        {
            try
            {
                return Ok(await CommandAsync(new RemoveCommand() {Id = id}));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE,
                    ErrorMessages.RemoveScheduleSettings.GetDescription(), ex.Message));
            }
        }
    }
}