using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TT.Diary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ApiControllerBase> _logger;

        public readonly string CLIENT_ERROR_MESSAGE = "{0}: {1}";

        public readonly string ERROR_GET_REQUEST = "Error trying to get {0} via {1}.";

        public readonly string ERROR_POST_REQUEST = "Error trying to post {0} via {1}.";

        public ApiControllerBase(ILogger<ApiControllerBase> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            try
            {
                return await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ERROR_GET_REQUEST, nameof(TResult), nameof(_mediator));
                throw;
            }
        }

        protected TResult Query<TResult>(IRequest<TResult> query)
        {
            try
            {
                return _mediator.Send(query).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ERROR_GET_REQUEST, nameof(TResult), nameof(_mediator));
                throw;
            }
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ERROR_POST_REQUEST, nameof(TResult), nameof(_mediator));
                throw;
            }
        }
    }
}