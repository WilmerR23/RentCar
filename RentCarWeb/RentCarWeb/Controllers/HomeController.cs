using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;

namespace RentCarWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private Manejador<Vehículo, VehículoDto> _Manejador;

        public ActionResult Index()
        {
            _Manejador = new Manejador<Vehículo, VehículoDto>();
            var entidad = _Manejador.ObtenerTodos(new[] { "Marca", "Modelo", "TipoVehiculo", "Imagenes" });
            return View(entidad);
        }
    }
}
