using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicLibrary.Api.Controllers
{

    /// <summary>
    /// Base controller class having basic call operations
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private const int _queryResponse = 200;
        private const int _commandResponse = 202;
        public readonly IMediator _mediator;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Injected IMetiator</param>
        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //awaity bardzo wazne

        /// <summary>
        /// Executes command and does not return data
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <returns>Accepted (202) code</returns>
        protected async Task<ActionResult> ExecuteCommand(Func<Task> command)
        {
            await command.Invoke();
            return Accepted();
        }

        /// <summary>
        /// Executed query and returns data
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="query">Command to execute</param>
        /// <returns>OK status (200) with return data</returns>
        protected async Task<ActionResult> ExecuteQuery<TResponse>(Func<Task<TResponse>> query)
        {
            var result = await query.Invoke();
            return Ok(result);
        }


        /// <summary>
        /// Execute command and returns result
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="command">Command to execute</param>
        /// <returns>Accepted (202) code with result</returns>
        protected async Task<ActionResult> ExecuteCommandWithResult<TResponse>(Func<Task<TResponse>> command)
        {
            var result = await command.Invoke();
            return Accepted(result);
        }

        /// <summary>
        /// Executes file download command
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <returns>File to download</returns>
        protected async Task<ActionResult> ExecuteFileDownload(Func<Task<(byte[],string)>> command)
        {
            var result = await command.Invoke();
            return File(result.Item1, "application/octet-stream",result.Item2);
        }
    }
}
