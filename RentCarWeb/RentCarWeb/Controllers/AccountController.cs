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
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account
        [Authorize]
        public ActionResult EditarPerfil()
        {
            UsuarioDto user = null;
            if (Session["userId"] != null)
            {
                var id = int.Parse(Session["userId"].ToString());
                user = _Manejador.ObtenerPorFiltro(x => x.Id == id);
            }
            ViewBag.idUsuario = user != null ? user.Id : 0;
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UsuarioDto user)
        {
            if (ModelState.IsValid)
            {
                string claveGenerada = user.Clave.generateShaText();
                var usuario = _Manejador.ObtenerPorFiltro(x => x.Correo.ToLower() == user.Correo.ToLower() && x.Clave == claveGenerada);

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                    //Session["user"] = usuario;
                    Session["userId"] = usuario.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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