using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL.Dtos
{
    public class RentaDevolucionDto : BaseEntityDto
    {
        public string Renta { get; set; }
        public int VehiculoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string MontoDia { get; set; }

        public bool ServicioDomicilio { get; set; }
        public string Dias { get; set; }
        public VehículoDto Vehiculo { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
