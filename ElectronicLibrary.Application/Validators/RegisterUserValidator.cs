using ElectronicLibrary.Application.CQRS.User.Commands;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator(ElectronicBookingSystemDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Custom((value, context) =>
              {
                  if (dbContext.Users.Any(x => x.Email == value))
                      context.AddFailure("This email is already taken");
              });

            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        }
    }
}
