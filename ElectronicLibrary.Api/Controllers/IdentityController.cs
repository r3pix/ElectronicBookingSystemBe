using ElectronicBookingSystem.Application.CQRS.Identity.Commands;
using ElectronicLibrary.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Api.Controllers
{
    public class IdentityController : BaseController
    {
        public IdentityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update([FromBody] UpdateIdentityCommand command) =>
                await ExecuteCommand(async () => await _mediator.Send(command));
    }
}
