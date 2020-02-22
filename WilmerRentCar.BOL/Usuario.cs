using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL
{
    public class Usuario : BaseEntity
    {
        public string Clave { get; set; }
        
        public string Correo { get; set; }

        public string Cedula { get; set; }
        public string TarjetaCredito { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

    }
}
