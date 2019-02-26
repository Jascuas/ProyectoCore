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
using Microsoft.AspNetCore.Mvc.Filters;
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




        public IActionResult Tienda(String tipo)
        {
            List<Producto> productos = repo.GetProductos();
            List<String> categorias = new List<String>();
            foreach(Producto p in productos)
            {
                categorias.Add(p.Tipo);
            }
            ViewBag.Tipos = categorias.Distinct().ToList();
            if (tipo != null)
            {
                productos = repo.GetProductos(tipo);
                ViewBag.Tipo = tipo;
            }
            return View(productos);
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
            
            List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
            Talla talla = repo.GetTalla(id_talla);

            Carro productoCarro = new Carro(producto, talla, unidades);
            if (carro != null )
            {
                if(carro.Exists(prod => prod.Talla.Id_Producto == id_producto && prod.Talla.Size == productoCarro.Talla.Size))
                {
                    foreach(Carro c in carro)
                    {
                        if (c.Talla.Id_Producto == id_producto && c.Talla.Size == productoCarro.Talla.Size)
                        {
                            int unidadesT = c.unidades + productoCarro.unidades;
                            if (c.Talla.Stock >= unidadesT)
                            {
                                c.unidades = unidadesT;
                                HttpContext.Session.SetObject<List<Carro>>("carro", carro);
                            }
                            else
                            {
                                ViewBag.Mensaje = "No puedes comprar mas de " + c.Talla.Stock + " de esta talla."; 
                            }
                        }
                    }
                }
                else
                {
                    carro.Add(productoCarro);
                    HttpContext.Session.SetObject<List<Carro>>("carro", carro);
                    HttpContext.Session.SetInt32("carritoCount", carro.Count());
                }
            }
            else
            {
                List<Carro> carronuevo = new List<Carro>();
                carronuevo.Add(productoCarro);
                HttpContext.Session.SetObject<List<Carro>>("carro", carronuevo);
                HttpContext.Session.SetInt32("carritoCount", carronuevo.Count());
            }

            return View(pro);
        }
        public IActionResult Carrito(int? id_talla)
        {
            List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
            if (id_talla != null)
            {
                Carro c = carro.Find(x => x.Talla.Id_Talla == id_talla);
                carro.Remove(c);
                HttpContext.Session.SetObject<List<Carro>>("carro", carro);
            }
           
            return View(carro);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Carrito(int id_talla, int unidades)
        //{
        //    List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
        //    Carro c = carro.Find(x => x.Talla.Id_Talla == id_talla);
        //    return View(carro);
        //}
    }
}