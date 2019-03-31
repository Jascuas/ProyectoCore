    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;

namespace Oberon.Controllers
{
    public class ValidacionController : Controller
    {
        IRepositoryAPIUsuarios repo;
        public ValidacionController(IRepositoryAPIUsuarios repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginCredentials credentials)
        {
            String token = await this.repo.GetToken(credentials);
            
            if (token != null)
            {
                HttpContext.Session.SetString("token", token);
                Usuario usuario = await this.repo.GetUsuario(token);
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Rol));
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Id_Usuario.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id_Usuario.ToString()));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    ,
                        ExpiresUtc = DateTime.Now.AddDays(30)
                    });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
                return View();
            }
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registro(RegisterCredentials credentials)
        {
            String mesaje = await this.repo.RegistrarUsuario(credentials);
            ViewBag.Mensaje = mesaje;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("carro");
            HttpContext.Session.Remove("carritoCount");
            return RedirectToAction("Index", "Home");
        }

    }
}