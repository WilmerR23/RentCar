using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL
{
    public class Clientes : BaseEntity {
        public string TarjetaCredito { get; set; }
        
        public List<RentaDevolucion> RentaDevoluciones { get; set; }


    }
}
