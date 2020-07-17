using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Schedule.Settings.Queries;
using TT.Diary.BusinessLogic.Schedule.Settings.Commands;
using TT.Diary.BusinessLogic.ViewModel;

namespace TT.Diary.WebAPI.Controllers.Schedule
{
    public class SettingsController : ApiControllerBase
    {
        public SettingsController(ILogger<SettingsController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<ScheduleSettings> Get(int id)
        {
            try
            {
                var data = Query<ScheduleSettings>(new GetQuery() { Id = id });
                if (data == null)
                    return NotFound();
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetSettings.GetDescription(), ex.Message));
            }
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
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SaveSettings.GetDescription(), ex.Message));
            }
        }
    }
}
