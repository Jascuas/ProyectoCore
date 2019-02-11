using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Filters;

namespace ProyectoCore.Controllers
{
    public class PerfilController : Controller
    {
        [UsuarioAuthorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}