using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Lists.ToDoList.Commands;
using TT.Diary.BusinessLogic.Lists.ToDoList.Queries;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.WebAPI.Controllers.Lists
{
    public class ToDoController : ApiControllerBase
    {
        public ToDoController(ILogger<ToDoController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ToDo<ScheduleSettingsSummary>>> Get(int id)
        {
            try
            {
                var data = await QueryAsync<ToDo<ScheduleSettingsSummary>>(new GetQuery() {Id = id});

                if (data == null)
                    return NotFound();

                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetToDo.GetDescription(),
                    ex.Message));
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
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.RemoveToDo.GetDescription(),
                    ex.Message));
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
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SaveToDo.GetDescription(),
                    ex.Message));
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
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SaveToDo.GetDescription(),
                    ex.Message));
            }
        }
    }
}