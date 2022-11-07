using ElectronicBookingSystem.Application.CQRS.Opinion.Commands;
using ElectronicBookingSystem.Application.CQRS.Opinion.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Opinion;
using ElectronicLibrary.Api.Controllers;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Api.Controllers
{
    public class OpinionController : BaseController
    {
        public OpinionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] AddOpinionCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("{RoomId}")]
        [ProducesResponseType(typeof(Response<IEnumerable<OpinionModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get([FromRoute] GetOpinionsQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpGet("is-allowed")]
        [ProducesResponseType(typeof(Response<bool>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetIsAllowed([FromQuery] CheckIsOpinionAllowedQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));
    }
}
