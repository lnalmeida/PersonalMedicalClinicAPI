using FluentValidation;
using PMC.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Manager.Validators
{
    public class UpdateClienteValidator : AbstractValidator<UpdateClienteModelView>
    {
        public UpdateClienteValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NewClienteValidator());
        }
    }
}
