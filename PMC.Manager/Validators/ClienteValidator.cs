using FluentValidation;
using PMC.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Manager.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(10).MaximumLength(200);
            RuleFor(x => x.BirthDate).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Document).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Matches("(\\(?\\d{2}\\)?\\s)?(\\d{4,5}\\-?\\d{4})").WithMessage("O número de telefone informado não é valido. O formato deve ser 99999999999 ou (99)99999-9999");
            RuleFor(x => x.Gender).NotNull().NotEmpty().Must(IsMaleOrFemale).WithMessage("O sexo só pode ser M ou F, não existem outros.");
        }

        private bool IsMaleOrFemale(char gender)
        {
            return gender == 'M' || gender == 'F';
        }
    }
}
