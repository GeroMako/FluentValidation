using Fluent_Validation.Entities;
using Fluent_Validation.Validaciones;

namespace FluentValidation
{
    class Program 
    {
        static void Main(string[] args)
        {
            AltaTarjeta A = new AltaTarjeta();

            Console.WriteLine("Ingrese Nombre");
            A.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            A.apellido = Console.ReadLine();
            Console.WriteLine("Ingrese email");
            A.email = Console.ReadLine();
            Console.WriteLine("Seleccione Mastercard o Visa");
            Console.WriteLine("1. Mastercard, 2. Visa");
            int numero = Int32.Parse(Console.ReadLine());
            if (numero == 1)
            {
                A.tipoTarjeta = "Mastercard";
                Console.WriteLine("Usted selecciono Mastercard");
            }
            else
            {
                A.tipoTarjeta = "Visa";
                Console.WriteLine("Usted selecciono Visa");
            }
            Console.WriteLine("Numero de la tarjeta");
            A.tarjeta = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de Vencimiento con formato (dd/mm/yyyy)");
            try
            {
                A.fechaVencimiento = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("La fecha debe tener el formato (dd/mm/yyyy)");
            }
            Console.WriteLine("Ingrese la fecha de nacimiento con formato (dd/mm/yyyy)");
            try
            {
                A.fechaNacimiento = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("La fecha debe tener el formato (dd/mm/yyyy)");
            }


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