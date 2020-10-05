using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.Lists.ToDoList.Queries;

namespace TT.Diary.WebAPI.Controllers.Lists
{
    public class ToDoListController : ApiControllerBase
    {
        public ToDoListController(ILogger<ToDoListController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{userid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<Category<ToDo>> Get(int userId)
        {
            try
            {
                var data = Query<Category<ToDo>>(new GetItemsQuery() { UserId = userId });
                if (data == null)
                    return NotFound();
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetToDoList.GetDescription(), ex.Message));
            }
        }
    }
}