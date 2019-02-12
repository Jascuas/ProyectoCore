    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;

namespace Oberon.Controllers
{
    public class ValidacionController : Controller
    {
        IRepositoryOberon repo;
        public ValidacionController(IRepositoryOberon repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(String email, String password)
        {
            Usuario usuario = this.repo.ExisteUsuario(email, password);
            if (usuario != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Rol));
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.User));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    ,
                        ExpiresUtc = DateTime.Now.AddMinutes(30)
                    });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
                return View();
            }
        }
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registro(String password, String nombre, String apellidos, String email)
        {
            this.repo.RegistrarUsuario(password, nombre, apellidos, email);
            Usuario usuario = this.repo.ExisteUsuario(email, password);
            if (usuario != null)
            {
                await Login(email, password);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
                return View();
            }
            
        }

    }
}