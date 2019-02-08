using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Oberon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tienda()
        {
            return View();
        }
        public IActionResult Sobre()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }

    }
}