using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL
{
    public class Modelo : BaseEntity
    {
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
