using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.TimeManagement.Queries;

namespace TT.Diary.WebAPI.Controllers.TimeManagement
{
    public class AnnualProductivityController : ApiControllerBase
    {
        public AnnualProductivityController(ILogger<AnnualProductivityController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<DailyProductivity>>> Get(int userId, DateTime startDate, DateTime finishDate)
        {
            try
            {
                return await QueryAsync<List<DailyProductivity>>(new GetAnnualProductivityQuery() { UserId = userId, StartDate = startDate, FinishDate = finishDate });
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetAnnualProductivity.GetDescription(), ex.Message));
            }
        }
    }
}
