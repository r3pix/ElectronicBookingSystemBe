using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Booking.Commands
{
    public class AddBookingCommandHandler : IRequestHandler<AddBookingCommand>
    {
        private readonly IRepository<Domain.Entities.Booking> _bookingRepository;
        private readonly IMapper _mapper;

        public AddBookingCommandHandler(IRepository<Domain.Entities.Booking> bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Booking>(request);
            await _bookingRepository.Save(entity);
            return default;
        }
    }
}
