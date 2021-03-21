using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Lists.Appointments.Queries;

namespace TT.Diary.WebAPI.Controllers.Lists.Appointments
{
    public class UnscheduledAppointmentsController : ApiControllerBase
    {
        public UnscheduledAppointmentsController(ILogger<UnscheduledAppointmentsController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category<Appointment<ScheduleSettingsSummary>>>> Get(int userId)
        {
            try
            {
                var data = await QueryAsync<Category<Appointment<ScheduleSettingsSummary>>>(new GetItemsQuery()
                    {UserId = userId, OnlyUnscheduled = true});

                if (data == null)
                    return NotFound();

                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetAppointments.GetDescription(),
                    ex.Message));
            }
        }
    }
}