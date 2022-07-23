using ElectronicLibrary.Application.CQRS.File.Queries;
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
    public class FileController : BaseController
    {
        public FileController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetFile([FromRoute] GetFileByIdQuery query) =>
            await ExecuteFileDownload(async () => await _mediator.Send(query));
    }
}
