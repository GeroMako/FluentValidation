using Fluent_Validation.Entities;
using Fluent_Validation.Validaciones;

namespace FluentValidation
{
    class Program 
    {
        static void Main(string[] args)
        {
            AltaTarjeta A = new AltaTarjeta();

            
            /* validador de datos personales*/
            var ValidacionDatospersonales = new ValidacionDatosPersonales();
            var resultadosPersonales = ValidacionDatospersonales.Validate(A);

            foreach (var error in resultadosPersonales.Errors)
            {
                Console.WriteLine(error.PropertyName + ":" + error.ErrorMessage);
            }

            /* validador de datos pagos*/
            var ValidacionDatosPago = new ValidacionDatosPago();
            var resultadosPagos = ValidacionDatosPago.Validate(A);

            foreach (var error in resultadosPagos.Errors)
            {
                Console.WriteLine(error.PropertyName + ":" + error.ErrorMessage);
            }

        }

    }

}