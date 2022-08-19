using ElectronicBookingSystem.Application.CQRS.Category.Commands;
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
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromBody] AddCategoryCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

    }
}
