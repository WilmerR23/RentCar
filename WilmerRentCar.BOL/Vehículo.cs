using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL
{
    public class Vehículo : BaseEntity
    {
        //public string Chasis { get; set; }
        //public string Motor { get; set; }
        public string Placa { get; set; }
        public int TipoVehiculoId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }

        public int Monto { get; set; }
        //public int TipoCombustibleId { get; set; }

        public int Año { get; set; }

        public TipoVehiculo TipoVehiculo { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        //public TipoCombustible TipoCombustible { get; set; }

        public List<RentaDevolucion> RentaDevoluciones { get; set; }
        public List<Imagenes> Imagenes { get; set; }

    }
}
