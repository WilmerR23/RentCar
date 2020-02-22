using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;

namespace RentCarWeb.Controllers
{
    public class VehiculoController : Controller
    {

        private Manejador<Marca, MarcaDto> _ManejadorMarca;
        private Manejador<Modelo, ModeloDto> _ManejadorModelo;
        private Manejador<TipoVehiculo, TipoVehiculoDto> _ManejadorTipoVehiculo;
        private Manejador<Imagenes, ImagenesDto> _ManejadorImagenes;


        public VehiculoController ()
        {
            _ManejadorImagenes = new Manejador<Imagenes, ImagenesDto>();
        }

        [HttpPost]
        public ActionResult UploadFiles(int vehiculoId)
        {
            HttpFileCollectionBase files = Request.Files;
            List<ImagenesDto> imagenes = new List<ImagenesDto>();
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    imagenes.Add(new ImagenesDto
                    {
                        Contenido = binaryReader.ReadBytes(file.ContentLength),
                        Formato = file.ContentType,
                        VehículoId = vehiculoId
                    });
                }
            }

            _ManejadorImagenes.CrearRange(imagenes);
            return Json(files.Count + " imagenes creadas");
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            _ManejadorMarca = new Manejador<Marca, MarcaDto>();
            _ManejadorModelo = new Manejador<Modelo, ModeloDto>();
            _ManejadorTipoVehiculo = new Manejador<TipoVehiculo, TipoVehiculoDto>();

            ViewBag.TipoVehiculo = _ManejadorTipoVehiculo.ObtenerTodos();
            ViewBag.Marca = _ManejadorMarca.ObtenerTodos();
            //ViewBag.Modelo = _ManejadorModelo.ObtenerTodos();
            return View();
        }
        
        [HttpGet]
        public JsonResult ObtenerModelos(int idMarca)
        {
            _ManejadorModelo = new Manejador<Modelo, ModeloDto>();
            var modelos = _ManejadorModelo.ObtenerTodosPorFiltro(x => x.MarcaId == idMarca);
            return Json(modelos,JsonRequestBehavior.AllowGet);
        }

    }
}