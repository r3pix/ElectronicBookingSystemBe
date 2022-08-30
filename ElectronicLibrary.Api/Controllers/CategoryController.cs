using ElectronicBookingSystem.Application.CQRS.Category.Commands;
using ElectronicBookingSystem.Application.CQRS.Category.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Category;
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
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromBody] AddCategoryCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand command) =>
                await ExecuteCommand(async () => await _mediator.Send(command));

        [HttpGet("pageable")]
        [ProducesResponseType(typeof(Response<PageableModel<CategoryListModel>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPageable([FromQuery] GetPageableCategoriesDto model) =>
            await ExecuteQuery(async () => await _mediator.Send(GetPageableCategoriesQuery.Create(model)));

        [HttpGet("GetForSelect")]
        [ProducesResponseType(typeof(Response<IEnumerable<SelectModel<Guid>>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetForSelect([FromQuery] GetCategoriesForSelectQuery query) =>
            await ExecuteQuery(async () => await _mediator.Send(query));

    }
}
