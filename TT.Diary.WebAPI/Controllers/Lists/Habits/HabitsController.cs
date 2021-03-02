using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Lists.Habits.Queries;

namespace TT.Diary.WebAPI.Controllers.Lists.Habits
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
        public async Task<ActionResult<Category<Habit<ScheduleSettingsSummary>>>> Get(int userId)
        {
            try
            {
                var data = await QueryAsync<Category<Habit<ScheduleSettingsSummary>>>(new GetItemsQuery()
                    {UserId = userId, OnlyUnscheduled = false});

                if (data == null)
                    return NotFound();

                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetHabits.GetDescription(),
                    ex.Message));
            }
        }
    }
}