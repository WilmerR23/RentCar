using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BOL.Dtos
{
    public class UsuarioDto : BaseEntityDto
    {
        [Display(Name = "Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña es requerida")]
        public string Clave { get; set; }

        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo no valido")]
        public string Correo { get; set; }

        public string Cedula { get; set; }
        public string TarjetaCredito { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
    }
}
