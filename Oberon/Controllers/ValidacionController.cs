using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Oberon.Controllers
{
    public class ValidacionController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }

    }
}