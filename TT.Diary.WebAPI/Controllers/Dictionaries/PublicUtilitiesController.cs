using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Habits.Commands;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.WebAPI.Controllers.Dictionaries
{
    public class PublicUtilitiesController : ApiControllerBase
    {
        private readonly IDataSettings _dataSettings;
        public PublicUtilitiesController(ILogger<PublicUtilitiesController> logger, IMediator mediator, IDataSettings dataSettings) : base(logger, mediator)
        {
            _dataSettings = dataSettings ?? throw new ArgumentNullException(nameof(dataSettings));
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> EditAsync([FromBody] EditCommand query)
        {
            try
            {
                if (query.CategoryId != _dataSettings.PublicUtilitiesCategoryId)
                {
                    throw new ArgumentException(ErrorMessages.IncorrectPublicUtilitiesCategoryId.GetDescription());
                }

                return Ok(await CommandAsync<int>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SavePublicUtilities.GetDescription(), ex.Message));
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddCommand query)
        {
            try
            {
                if (query.CategoryId != _dataSettings.PublicUtilitiesCategoryId)
                {
                    throw new ArgumentException(ErrorMessages.IncorrectPublicUtilitiesCategoryId.GetDescription());
                }

                return Created(nameof(AddAsync), await CommandAsync<int>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.SavePublicUtilities.GetDescription(), ex.Message));
            }
        }
    }
}