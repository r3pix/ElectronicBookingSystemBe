using ElectronicLibrary.Application.CQRS.Service.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Validators
{
    public class AddServiceCommandValidator : AbstractValidator<AddServiceCommand>
    {
        public AddServiceCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(2);
        }
    }
}
