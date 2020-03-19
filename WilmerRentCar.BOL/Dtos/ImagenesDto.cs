using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL.Dtos
{
    public class ImagenesDto : BaseEntityDto
    {
        public byte[] Contenido { get; set; }

        public string Formato { get; set; }

        public int VehículoId { get; set; }

        public string ContenidoBase64 { get => Convert.ToBase64String(Contenido);}

        //public VehículoDto Vehículo { get; set; }
    }
}
