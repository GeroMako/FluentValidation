using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Validation.Entities
{
    public class AltaTarjeta
    {
        public string nombre { get; set; } //requerido
        public string apellido { get; set; } //requerido y no puede ser igual que el nombre
        public string email { get; set; } //requerido y que sea mail
        public string tipoTarjeta { get; set; }//requerido y debe ser VIS o MAS
        public string tarjeta { get; set; }//Si se carga tipo tarjeta, es requerido y dene ser un nro de tarjeta valido
        public DateTime fechaVencimiento { get; set; } // requerido y sea posterior a Hoy+3 meses
        public DateTime fechaNacimiento { get; set; } // Mayor de 18 y menor de 70 años


    }
}
