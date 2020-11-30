using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TT.Diary.BusinessLogic.Configurations;
using TT.Diary.BusinessLogic.Configurations.Extensions;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.Lists.Notes.Queries;

namespace TT.Diary.WebAPI.Controllers.Lists
{
    public class NotesController : ApiControllerBase
    {
        public NotesController(ILogger<NotesController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category<Note>>> Get(int userId)
        {
            try
            {
                var data = await QueryAsync<Category<Note>>(new GetItemsQuery() { UserId = userId });

                if (data == null)
                    return NotFound();

                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CLIENT_ERROR_MESSAGE, ErrorMessages.GetNoteList.GetDescription(), ex.Message));
            }
        }
    }
}