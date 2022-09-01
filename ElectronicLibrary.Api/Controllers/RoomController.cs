using ElectronicBookingSystem.Application.CQRS.Room.Commands;
using ElectronicBookingSystem.Application.CQRS.Room.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Room;
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
    /*
    [ApiController]
    [Authorize]
    [Route("api/[controller]")] */
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

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update([FromBody] UpdateRoomCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));
        

        [HttpGet("list")]
        [ProducesResponseType(typeof(Response<IEnumerable<RoomListModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetRoomList([FromQuery] GetMainPageRoomsDto model) =>
            await ExecuteQuery(async () => await _mediator.Send(GetRoomListQuery.Create(model)));

        [HttpGet("pageable")]
        [ProducesResponseType(typeof(Response<PageableModel<RoomListModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPageable([FromQuery] GetPageableRoomsDto model) =>
            await ExecuteQuery(async () => await _mediator.Send(GetPageableRoomsQuery.Create(model)));


        [HttpPut("edit-picture")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> EditFile([FromForm] EditRoomPictureCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));
        
    }
}
