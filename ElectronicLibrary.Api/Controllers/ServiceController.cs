using ElectronicBookingSystem.Application.CQRS.Service.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Service;
using ElectronicLibrary.Application.CQRS.Service.Commands;
using ElectronicLibrary.Application.CQRS.Service.Queries;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceController : BaseController
    {
        public ServiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromBody] AddServiceCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("GetForSelect")]
        [ProducesResponseType(typeof(Response<IEnumerable<SelectModel<Guid>>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetForSelect([FromQuery] GetServicesForSelectQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Response<ServiceModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetById([FromRoute] GetServiceByIdQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));
    }
}
