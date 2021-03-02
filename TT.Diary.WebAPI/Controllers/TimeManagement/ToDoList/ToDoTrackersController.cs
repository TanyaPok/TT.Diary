using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.TimeManagement.ToDoTracker.Commands;

namespace TT.Diary.WebAPI.Controllers.TimeManagement.ToDoList
{
    public class ToDoTrackersController : ApiControllerBase
    {
        public ToDoTrackersController(ILogger<ToDoTrackersController> logger, IMediator mediator) : base(logger,
            mediator)
        {
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> RemoveAsync(int id)
        {
            try
            {
                return Ok(await CommandAsync(new RemoveCommand() {OwnerId = id}));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.RemoveTracker.GetDescription(),
                    ex.Message));
            }
        }
    }
}