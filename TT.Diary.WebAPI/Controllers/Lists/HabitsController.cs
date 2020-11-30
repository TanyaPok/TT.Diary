using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.Lists.Habits.Queries;

namespace TT.Diary.WebAPI.Controllers.Lists
{
    public class HabitsController : ApiControllerBase
    {
        public HabitsController(ILogger<HabitsController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category<Habit>>> Get(int userId, bool onlyUnscheduled)
        {
            try
            {
                var data = await QueryAsync<Category<Habit>>(new GetItemsQuery() { UserId = userId, OnlyUnscheduled = onlyUnscheduled });

                if (data == null)
                    return NotFound();

                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetHabits.GetDescription(), ex.Message));
            }
        }
    }
}
