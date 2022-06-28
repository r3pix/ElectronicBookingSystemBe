using ElectronicLibrary.Application.CQRS.Room.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Validators
{
    /// <summary>
    /// Validation class for Room entity
    /// </summary>
    public class AddRoomCommandValidator : AbstractValidator<AddRoomCommand>
    {
        public AddRoomCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(256).MinimumLength(5);
            RuleFor(x => x.TotalMaxPlaces).NotEmpty();
            RuleFor(x => x.TotalMaxTables).NotEmpty();
        }
    }
}
