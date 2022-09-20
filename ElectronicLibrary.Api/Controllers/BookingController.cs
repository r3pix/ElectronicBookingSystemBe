using ElectronicBookingSystem.Application.CQRS.Booking.Queries;
using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Application.CQRS.Booking.Commands;
using ElectronicLibrary.Infrastructure.Extensions;
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

        [HttpGet("pageable")]
        [ProducesResponseType(typeof(Response<PageableModel<BookingListModel>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> Pageable([FromQuery] GetPageableBookingsQueryDto dto) =>
            await ExecuteQuery(async () => await _mediator.Send(GetPageableBookingsQuery.Create(dto)));

        [HttpPut("cancel/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CancelBooking([FromRoute] CancelBookingCommand command) =>
            await ExecuteCommand(async () => await _mediator.Send(command));
    }
}
