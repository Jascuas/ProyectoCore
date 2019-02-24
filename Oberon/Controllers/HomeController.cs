using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oberon.Models;
using Oberon.Repositories;
using Oberon.Extensions;
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
            List<Talla> tallas = repo.GetTallasProducto(id_producto);
            ViewBag.Tallas = tallas;
            ProductoTalla pro = new ProductoTalla(producto, tallas);
            return View(pro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Producto(int id_producto, int id_talla, int unidades)
        {
            
            Producto producto = repo.GetProducto(id_producto);
            List<Talla> tallas = repo.GetTallasProducto(id_producto);
            ViewBag.Tallas = tallas;
            ProductoTalla pro = new ProductoTalla(producto, tallas);

            Carro carro = HttpContext.Session.GetObject<Carro>("carro");


            Talla talla = repo.GetTalla(id_talla);
            ProductoCarro productoCarro = new ProductoCarro(pro, talla, unidades);
            
            if (carro != null)
            {
                carro.Productos.Add(productoCarro);
                HttpContext.Session.SetObject<Carro>("carro", carro);
                HttpContext.Session.SetInt32("carritoCount", carro.Productos.Count());
            }
            else
            {
                List<ProductoCarro> productos = new List<ProductoCarro>();
                productos.Add(productoCarro);
                Carro carronuevo = new Carro(productos);
                HttpContext.Session.SetObject<Carro>("carro", carronuevo);
                HttpContext.Session.SetInt32("carritoCount", 1);
            }
            
            return View(pro);
        }
       
    }
}