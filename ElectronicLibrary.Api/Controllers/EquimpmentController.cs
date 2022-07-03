using ElectronicLibrary.Application.CQRS.Equipment.Commands;
using ElectronicLibrary.Application.CQRS.Equipment.Queries;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class EquimpmentController : BaseController
    {
        public EquimpmentController(IMediator mediator) :base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromForm] AddEquipmentCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("GetForSelect")]
        [ProducesResponseType(typeof(Response<IEnumerable<SelectModel<Guid>>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetForSelect([FromQuery] GetEquipmentForSelectQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));
    }
}
