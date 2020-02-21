using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL
{
    public class Imagenes : BaseEntity
    {

        public byte[] Contenido { get; set; }

        public string Formato { get; set; }

        public int VehículoId { get; set; }

        public Vehículo Vehículo {get; set;}

        public string ContenidoBase64 { get; set; }

    }
}
