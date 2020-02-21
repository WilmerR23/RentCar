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
                string claveGenerada = user.Clave.generateShaText();
                var usuario = _Manejador.ObtenerPorFiltro(x => x.Correo.ToLower() == user.Correo.ToLower() && x.Clave == claveGenerada);

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Correo, true);
                    Session["user"] = usuario;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UsuarioDto user)
        {
            if (ModelState.IsValid)
            {
                user.Clave = user.Clave.generateShaText();
                _Manejador.Crear(user,true);
            }
            return View("Login");
        }
    }
}