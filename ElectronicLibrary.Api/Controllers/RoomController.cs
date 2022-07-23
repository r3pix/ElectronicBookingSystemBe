using ElectronicLibrary.Application.CQRS.Room.Commands;
using ElectronicLibrary.Application.CQRS.Room.Queries;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Models.Room;
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
    /// <summary>
    /// Controller handling requests for Room entity
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RoomController : BaseController
    {
        public RoomController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Method executing "Create" command
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <returns>Created (202) status</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromForm] AddRoomCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("list")]
        [ProducesResponseType(typeof(Response<IEnumerable<RoomListModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetRoomList([FromQuery] GetRoomListQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));
    }
}
