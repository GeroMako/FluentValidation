using Fluent_Validation.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Validation.Validaciones
{
    public class ValidacionDatosPago : AbstractValidator<AltaTarjeta>
    {
        public ValidacionDatosPago() 
        {
            RuleFor(r => r.tipoTarjeta)
                .NotEmpty()
                .Must(validaTipoTarjeta);

            RuleFor(r => r.tarjeta)
                .NotEmpty().When(validaIngresoTarjeta)
                .CreditCard();
            RuleFor(r => r.fechaVencimiento).GreaterThan(DateTime.Now.AddMonths(3));
            RuleFor(r => r.fechaNacimiento).Must(ValidaEdad);
        }

        private bool validaTipoTarjeta(string tipo)
        {
            if (tipo == "VISA" || tipo == "MASTERCARD") return true;return false;
        }

        private bool validaIngresoTarjeta(AltaTarjeta alta)
        {
            if (alta.tipoTarjeta != null & alta.tipoTarjeta != "") return true; return false;
        }
        private bool ValidaEdad(DateTime fechanacimiento)
        {
            int edad = DateTime.Now.Year - fechanacimiento.Year;
            if (DateTime.Now.Month > fechanacimiento.Month) --edad;

            if (edad >= 18 && edad <= 70) return true;return false;
                    
        }
    }
}
