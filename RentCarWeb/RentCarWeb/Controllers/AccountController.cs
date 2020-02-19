using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;
using WilmerRentCar.UTL;

namespace RentCarWeb.Controllers
{
    public class AccountController : Controller
    {
        private Manejador<Usuario,UsuarioDto> _Manejador;

        public AccountController()
        {
            _Manejador = new Manejador<Usuario, UsuarioDto>();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioDto user)
        {
            if (ModelState.IsValid)
            {
                var usuario = _Manejador.ObtenerPorFiltro(x => x.Correo.ToLower() == user.Correo.ToLower() && x.Clave == user.Clave.generateShaText());

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Nombre, true);
                    Session["user"] = usuario.Nombre;
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(user);
        }
    }
}