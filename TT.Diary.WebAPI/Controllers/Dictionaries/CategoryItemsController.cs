using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Queries;
using TT.Diary.BusinessLogic.DTO;

namespace TT.Diary.WebAPI.Controllers.Dictionaries
{
    public class CategoryItemsController : ApiControllerBase
    {
        public CategoryItemsController(ILogger<CategoryItemsController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var data = Query<Category>(new GetItemsQuery { Id = id });
                if (data == null)
                    return NotFound();
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetCategoryItems.GetDescription(), ex.Message));
            }
        }
    }
}