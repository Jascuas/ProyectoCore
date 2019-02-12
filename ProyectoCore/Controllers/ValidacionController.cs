using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCore.Controllers
{
    public class ValidacionController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(String usuario, String password)
        {
            if (usuario == "admin" && password == "admin")
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario));
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    ,
                        ExpiresUtc = DateTime.Now.AddMinutes(30)
                    });
                return RedirectToAction("Index", "Perfil");
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


    }
}