using RentCarWeb.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;

namespace RentCarWeb.Controllers.api
{
    [RoutePrefix("api/Vehiculo")]
    [Authorize]
    public class VehiculoController : ApiController
    {
        private Manejador<Vehículo, VehículoDto> _Manejador;
        private Manejador<RentaDevolucion, RentaDevolucionDto> _ManejadorRenta;
        private Manejador<Imagenes, ImagenesDto> _ManejadorImagenes;

        public VehiculoController()
        {
            _Manejador = new Manejador<Vehículo, VehículoDto>(); 
            _ManejadorRenta = new Manejador<RentaDevolucion, RentaDevolucionDto>();
            _ManejadorImagenes = new Manejador<Imagenes, ImagenesDto>();
        }

        [HttpPost]
        [Route("GuardarVehiculo")]
        public IHttpActionResult GuardarVehiculo([FromBody] VehículoDto vm)
        {

            if (vm.Id != 0)
            {
                vm =  _Manejador.Actualizar(vm);
            }
            else
            {
                vm = _Manejador.CrearSync(vm, true);
            }
            return Ok(vm.Id);
        }

        [HttpPost]
        [Route("RentaVehiculo")]
        public IHttpActionResult RentaVehiculo([FromBody] RentaDevolucionDto vm)
        {
            vm.UsuarioId = Convert.ToInt32(HttpContext.Current.Session["userId"]?.ToString());
            vm = _ManejadorRenta.CrearSync(vm, true);
            return Ok(vm.Id);
        }

        [HttpGet]
        [Route("ObtenerVehiculos")]
        public IHttpActionResult ObtenerVehiculos()
        {
            var entidad = _Manejador.ObtenerTodos(new[] { "Marca", "Modelo", "TipoVehiculo" });
            return Ok(entidad);
        }

        [HttpGet]
        [Route("ObtenerVehiculo/{id}")]
        public IHttpActionResult ObtenerVehiculo([FromUri] int id)
        {
            var entidad = _Manejador.ObtenerPorFiltro(x => x.Id == id);
            return Ok(entidad);
        }

        [HttpGet]
        [Route("ObtenerImagenes/{id}")]
        public IHttpActionResult ObtenerImagenes([FromUri] int id)
        {
            var entidad = _ManejadorImagenes.ObtenerTodosPorFiltro(x => x.VehículoId == id).ToList();
            
            for(int x = 0; x < entidad.Count(); x++)
            {
                entidad[x].ContenidoBase64 = Convert.ToBase64String(entidad[x].Contenido);
            }
            
            return Ok(entidad);
        }


        [HttpGet]
        [Route("BorrarVehiculo/{id}")]
        public IHttpActionResult BorrarVehiculo([FromUri] int id)
        {
            _Manejador.Eliminar(id);
            return Ok();
        }

        
    }
}
