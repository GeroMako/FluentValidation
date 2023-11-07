using Fluent_Validation.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Validation.Validaciones
{
    public class ValidacionDatosPersonales : AbstractValidator<AltaTarjeta>
    {
        public ValidacionDatosPersonales() 
        {
            RuleFor(r => r.nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MinimumLength(3);

            RuleFor(r => r.apellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(4);
                .NotEqual(r => r.nombre);

            RuleFor(r => r.email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
