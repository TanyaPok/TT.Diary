using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Lists.WishList.Queries;

namespace TT.Diary.WebAPI.Controllers.Lists
{
    public class WishListController : ApiControllerBase
    {
        public WishListController(ILogger<WishListController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category<Wish<ScheduleSettingsSummary>>>> Get(int userId)
        {
            try
            {
                var data = await QueryAsync<Category<Wish<ScheduleSettingsSummary>>>(new GetItemsQuery()
                    {UserId = userId});

                if (data == null)
                    return NotFound();

                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetWishList.GetDescription(),
                    ex.Message));
            }
        }
    }
}