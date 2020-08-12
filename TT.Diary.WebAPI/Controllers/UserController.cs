using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Users.Commands;

namespace TT.Diary.WebAPI.Controllers
{
    public class UserController : ApiControllerBase
    {
        public UserController(ILogger<UserController> logger, IMediator mediator) : base(logger, mediator)
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
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SetUserUp.GetDescription(), ex.Message));
            }
        }
    }
}
