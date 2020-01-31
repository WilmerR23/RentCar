using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL.Dtos
{
    public class VehículoDto : BaseEntityDto
    {
        public string Chasis { get; set; }
        public string Motor { get; set; }
        public string Placa { get; set; }
        public int TipoVehiculoId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public int TipoCombustibleId { get; set; }

        public TipoVehiculoDto TipoVehiculo { get; set; }
        public MarcaDto Marca { get; set; }
        public ModeloDto Modelo { get; set; }
        public TipoCombustibleDto TipoCombustible { get; set; }
    }
}
