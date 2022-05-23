using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicLibrary.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //awaity bardzo wazne

        public async Task<ActionResult> ExecuteCommand(Func<Task> command)
        {
            await command.Invoke();
            return Accepted();
        }

        public async Task<ActionResult> ExecuteQuery<TResponse>(Func<Task<TResponse>> query)
        {
            var result = await query.Invoke();
            return Ok(result);
        }

        public async Task<ActionResult> ExecuteCommandWithResult<TResponse>(Func<Task<TResponse>> command)
        {
            var result = await command.Invoke();
            return Accepted(result);
        }
    }
}
