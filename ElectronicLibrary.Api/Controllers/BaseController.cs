using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicLibrary.Api.Controllers
{
    //[ApiController]
    //[Authorize]
    //[Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private const int _queryResponse = 200;
        private const int _commandResponse = 202;
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //awaity bardzo wazne

        protected async Task<ActionResult> ExecuteCommand(Func<Task> command)
        {
            await command.Invoke();
            return Accepted();
        }

        protected async Task<ActionResult> ExecuteQuery<TResponse>(Func<Task<TResponse>> query)
        {
            var result = await query.Invoke();
            return Ok(result);
        }

        protected async Task<ActionResult> ExecuteCommandWithResult<TResponse>(Func<Task<TResponse>> command)
        {
            var result = await command.Invoke();
            return Accepted(result);
        }

        protected async Task<ActionResult> ExecuteFileDownload(Func<Task<(byte[],string)>> command)
        {
            var result = await command.Invoke();
            return File(result.Item1, "application/octet-stream",result.Item2);
        }
    }
}
