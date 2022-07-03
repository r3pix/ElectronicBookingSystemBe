using ElectronicLibrary.Application.CQRS.Equipment.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Validators
{
    public class AddEquipmentCommandValidator : AbstractValidator<AddEquipmentCommand>
    {
        public AddEquipmentCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.File).NotEmpty();
        }
    }
}
