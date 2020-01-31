using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL.Dtos
{
    public class ClientesDto : BaseEntityDto
    {
        public string TarjetaCredito { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }
    }
}
