using Combis.Backend.DTO;
using Combis.Backend.Models;
using FluentValidation;
using System;
using System.Linq;

namespace Combis.Backend.Utilities.Validations
{
    public class PersonValidation : AbstractValidator<PersonDTO>
    {
        public PersonValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.PhoneNumber).Must(x => x.Contains("+")).Must(x => !x.Contains(" "));
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.ZipCode).NotNull().GreaterThanOrEqualTo(1);
            RuleFor(x => x.City).NotEmpty();
        }
    }
}
