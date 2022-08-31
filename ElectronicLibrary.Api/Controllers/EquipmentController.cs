using ElectronicBookingSystem.Application.CQRS.Decoration.Queries;
using ElectronicBookingSystem.Application.CQRS.Equipment.Commands;
using ElectronicBookingSystem.Application.CQRS.Equipment.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Equipment;
using ElectronicLibrary.Application.CQRS.Equipment.Commands;
using ElectronicLibrary.Application.CQRS.Equipment.Queries;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicLibrary.Api.Controllers
{
    /*
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]*/
    public class EquipmentController : BaseController
    {
        public EquipmentController(IMediator mediator) :base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromForm] AddEquipmentCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update([FromBody] UpdateEquipmentCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("GetForSelect")]
        [ProducesResponseType(typeof(Response<IEnumerable<SelectModel<Guid>>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetForSelect([FromQuery] GetEquipmentForSelectQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Response<EquipmentModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetById([FromRoute] GetDecorationByIdQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

        [HttpGet("pageable")]
        [ProducesResponseType(typeof(Response<PageableModel<EquipmentListModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Pageable([FromQuery] GetPageableEquipmentDto model) =>
            await ExecuteQuery(async () => await _mediator.Send(GetPageableEquipmentQuery.Create(model)));

        [HttpPut("edit-picture")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> EditPicture([FromForm] EditEquipmentPictureCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));
    }
}
