using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;

namespace RentCarWeb.Controllers.api
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private Manejador<Usuario, UsuarioDto> _Manejador;

        public AccountController()
        {
            _Manejador = new Manejador<Usuario, UsuarioDto>();
        }

        [HttpPost]
        [Route("EditarPerfil")]
        public IHttpActionResult EditarPerfil([FromBody] UsuarioDto vm)
        {
            UsuarioDto entidad = new UsuarioDto();
            if (vm.Id != 0)
            {
                UsuarioDto vm2 = _Manejador.ObtenerPorFiltro(x => x.Id == vm.Id);
                vm.Clave = vm2.Clave;
                vm.Correo = vm2.Correo;
                entidad = _Manejador.Actualizar(vm);
                //Session["user"] = entidad;
            }
            return Ok(entidad.Id);
        }
    }
}
