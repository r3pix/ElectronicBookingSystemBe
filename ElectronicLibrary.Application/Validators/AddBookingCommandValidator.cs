using ElectronicBookingSystem.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Validators
{
    public class AddBookingCommandValidator : AbstractValidator<Booking>
    {
        public AddBookingCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.TotalCost).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.DecorationId).NotEmpty();
            RuleFor(x => x.EquipmentId).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.ServiceId).NotEmpty();
            RuleFor(x=>x.UserId).NotEmpty();
        }
    }
}
