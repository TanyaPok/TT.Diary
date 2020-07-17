using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Queries;
using TT.Diary.BusinessLogic.ViewModel;

namespace TT.Diary.WebAPI.Controllers.Dictionaries
{
    public class CategoriesController : ApiControllerBase
    {
        public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<List<Category>> Get()
        {
            try
            {
                var data = Query<List<Category>>(new GetAllCategoriesQuery());
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetCategoryItems.GetDescription(), ex.Message));
            }
        }
    }
}
