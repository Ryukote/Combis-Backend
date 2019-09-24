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
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Surname)
                .NotEmpty();
            RuleFor(x => x.PhoneNumber)
                .Must(x => x.Contains("+"))
                .Must(x => !x.Contains(" "));
            RuleFor(x => x.Surname)
                .NotEmpty();
            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Must(x => int.TryParse(x, out int n))
                .Must(x => int.Parse(x) > 0);
        }
    }
}
