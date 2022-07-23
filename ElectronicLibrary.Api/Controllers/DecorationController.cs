using ElectronicBookingSystem.Application.CQRS.Decoration.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Application.CQRS.Decoration.Commands;
using ElectronicLibrary.Application.CQRS.Decoration.Queries;
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
    public class DecorationController : BaseController
    {
        public DecorationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromForm] AddDecorationCommand command) =>
                await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("GetForSelect")]
        [ProducesResponseType(typeof(Response<IEnumerable<SelectModel<Guid>>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetForSelect([FromQuery] GetDecorationsForSelectQuery query) =>
               await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Response<DecorationModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetById([FromRoute] GetDecorationByIdQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));
    }
}
