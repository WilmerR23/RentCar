using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WilmerRentCar.BOL.Dtos
{
    public class VehículoDto : BaseEntityDto
    {
        public string Placa { get; set; }
        public int TipoVehiculoId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }

        public int Año { get; set; }

        public int Monto { get; set; }

        public TipoVehiculoDto TipoVehiculo { get; set; }
        public MarcaDto Marca { get; set; }
        public ModeloDto Modelo { get; set; }
        public List<ImagenesDto> Imagenes { get; set; }


        public string ModeloDescripcion { get; set; }
        public string TipoVehiculoDescripcion { get; set; }
        public string MarcaDescripcion { get; set; }

        public string ImagenPrincipal { get; set; }
    }
}
