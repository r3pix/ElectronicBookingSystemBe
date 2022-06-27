using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibrary.Api.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("api/[controller]")]
    public class RoomController : BaseController
    {
        public RoomController(IMediator mediator) : base(mediator)
        {
        }



    }
}
