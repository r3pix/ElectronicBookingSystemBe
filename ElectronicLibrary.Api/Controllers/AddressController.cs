using ElectronicBookingSystem.Application.CQRS.Address.Commands;
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
    public class AddressController : BaseController
    {
        public AddressController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update([FromBody] UpdateAddressCommand command) =>
                await ExecuteCommand(async () => await _mediator.Send(command));

    }
}
