using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Habits.Commands;
using TT.Diary.BusinessLogic.Dictionaries.Habits.Queries;
using TT.Diary.BusinessLogic.ViewModel;

namespace TT.Diary.WebAPI.Controllers.Dictionaries
{
    public class HabitController: ApiControllerBase
    {
        public HabitController(ILogger<HabitController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<Habit> Get(int id)
        {
            try
            {
                var data = Query<Habit>(new GetQuery() { Id = id });
                if (data == null)
                    return NotFound();
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetHabit.GetDescription(), ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> RemoveAsync(int id)
        {
            try
            {
                return Ok(await CommandAsync(new RemoveCommand() { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.RemoveHabit.GetDescription(), ex.Message));
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> EditAsync([FromBody] EditCommand query)
        {
            try
            {
                return Ok(await CommandAsync<int>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SaveHabit.GetDescription(), ex.Message));
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddCommand query)
        {
            try
            {
                return Created(nameof(AddAsync), await CommandAsync<int>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SaveHabit.GetDescription(), ex.Message));
            }
        }
    }
}