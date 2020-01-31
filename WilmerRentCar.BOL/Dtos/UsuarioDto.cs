using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL.Dtos
{
    public class UsuarioDto : BaseEntityDto
    {
        public string Clave { get; set; }
        public int EmpleadoId { get; set; }
    }
}
