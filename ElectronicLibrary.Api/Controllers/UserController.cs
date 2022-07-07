using ElectronicLibrary.Application.CQRS.User.Commands;
using ElectronicLibrary.Application.CQRS.User.Querries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> LoginUser([FromBody] RegisterUserCommand command) =>
            await ExecuteQuery(async () => await _mediator.Send(command));

    }
}
