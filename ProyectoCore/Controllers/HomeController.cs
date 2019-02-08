using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoCore.Extensions;
using ProyectoCore.Models;

namespace ProyectoCore.Controllers
{
    public class HomeController : Controller
    {
        ILogger log;
        public HomeController(ILogger<HomeController> log)
        {

            this.log = log;
        }
        public IActionResult Index()
        {
            log.LogInformation("Hemos entrado en el index de home"); 
            return View();
        }
        public IActionResult About(String usuario)
        {
            log.LogInformation("Hemos entrado en el About de home");
            ViewData["SALUDO"] = "Hola usuario " + usuario;
            return View();
        }
        public ActionResult Donativos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Donativos(String nombre, int donativo)
        {

            ViewData["MENSAJE"] = "Su donativo de "
                + donativo
                + "€ ha sido almacenado.  " +
                "Sr/Sra " + nombre;
            Trace.TraceInformation(nombre + " " + donativo + "€.");
            MetricTelemetry metrica = new MetricTelemetry();
            metrica.Name = "Donativos";
            metrica.Sum = donativo;
            TelemetryClient client = new TelemetryClient();
            client.TrackEvent("Evento Donativos");
            client.TrackMetric(metrica);
            return View();
        }

        public IActionResult MiSesion(string accion)
        {
            if (accion == null || accion == "guardar")
            {
                ViewData["MENSAJE"] = "Guardando Session";
                HttpContext.Session.SetString("Nombre", "Lucia");
                HttpContext.Session.SetInt32("Edad", 15);
            }
            else
            {
                ViewData["MENSAJE"] = "Almacenando Session";
                ViewData["NOMBRE"] = HttpContext.Session.GetString("Nombre");
                ViewData["EDAD"] = HttpContext.Session.GetInt32("Edad");
            }
            return View();
        }
        public IActionResult AboutSession(String accion)
        {
            if (accion == null || accion == "guardar")
            {
                Informacion info = new Informacion();
                info.Autor = "Programeitor";
                info.Edad = 24;
                HttpContext.Session.SetObject<Informacion>("Info", info);
                ViewData["MENSAJE"] = "Guardando sesión...";
            }
            else if (accion == "mostrar")
            {
                Informacion info = HttpContext.Session.GetObject<Informacion>("Info");
                ViewData["NOMBRE"] = info.Autor;
                ViewData["EDAD"] = info.Edad;
                ViewData["MENSAJE"] = "Mostrando sesión";
            }
            return View();
        }

    }
}