using ElectronicLibrary.Application.CQRS.Booking.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace ElectronicLibrary.Api.Controllers
{
    /*
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]*/
    public class BookingController : BaseController
    {
        public BookingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Create([FromBody] AddBookingCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));
    }
}
