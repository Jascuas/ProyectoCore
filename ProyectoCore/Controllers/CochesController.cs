using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;

namespace ProyectoCore.Controllers
{
    public class CochesController : Controller
    {
        ICoche car;

        public CochesController(ICoche car)
        {
            this.car = car;
        }

        public IActionResult Index()
        {
            return View(this.car);
        }
        [HttpPost]
        public IActionResult Index(String action)
        {
            if (action == "acelerar") this.car.Acelerar();
            else this.car.Frenar();
            ViewData["MENSAJE"] = this.car.VelocidadActual;
            return View(this.car);
        }
    }
}