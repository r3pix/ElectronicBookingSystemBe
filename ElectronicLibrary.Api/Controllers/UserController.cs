using ElectronicBookingSystem.Application.CQRS.User.Querries;
using ElectronicBookingSystem.Infrastructure.Models.User;
using ElectronicLibrary.Application.CQRS.User.Commands;
using ElectronicLibrary.Application.CQRS.User.Querries;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Response<string>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpGet("userData")]
        [ProducesResponseType(typeof(Response<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetUserData([FromQuery] GetUserDataQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

    }
}
