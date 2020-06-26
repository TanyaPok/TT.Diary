using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.Dictionaries.Categories.Queries;
using TT.Diary.BusinessLogic.ViewModel;

namespace TT.Diary.WebAPI.Controllers.Dictionaries
{
    public class BooksController : ApiControllerBase
    {
        public BooksController(ILogger<BooksController> logger, IMediator mediator) : base(logger, mediator)
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
                var data = Query<Category>(new GetBooksQuery { Id = id });
                if (data == null)
                    return NotFound();
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetBooks.GetDescription(), ex.Message));
            }
        }
    }
}