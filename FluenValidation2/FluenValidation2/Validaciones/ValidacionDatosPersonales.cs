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
                .NotEmpty().WithMessage("El nombre es obligatorio");

            RuleFor(r => r.apellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotEqual(r => r.apellido);

            RuleFor(r => r.email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
