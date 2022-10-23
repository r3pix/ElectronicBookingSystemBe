using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Booking.Commands
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand>
    {
        private readonly IRepository<Domain.Entities.Booking> _repository;

        public CancelBookingCommandHandler(IRepository<Domain.Entities.Booking> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByPredicate(x=>x.Id == request.Id);
            entity.IsActive = false;
            await _repository.SaveChangesAsync();
            return default;
        }
    }
}
