using ElectronicLibrary.Application.CQRS.Decoration.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Validators
{
    /// <summary>
    /// Validator class for AddDecorationCommand
    /// </summary>
    public class AddDecorationCommandValidator : AbstractValidator<AddDecorationCommand>
    {
        public AddDecorationCommandValidator()
        {
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
