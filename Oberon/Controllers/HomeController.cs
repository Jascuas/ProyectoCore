using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oberon.Models;
using Oberon.Repositories;

namespace Oberon.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryOberon repo;
        public HomeController(IRepositoryOberon repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
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




        public IActionResult Tienda()
        {
            List<Producto> productos = repo.GetProductos();
            List<String> categorias = new List<String>();
            foreach(Producto p in productos)
            {
                categorias.Add(p.Tipo + "s");
            }
            ViewBag.Tipos = categorias.Distinct().ToList();
            return View(productos);
        }
        public IActionResult Carrito()
        {
            return View();
        }
        public IActionResult Producto(int id_producto)
        {
            Producto producto = repo.GetProducto(id_producto);
            return View(producto);
        }




    }
}