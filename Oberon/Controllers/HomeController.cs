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
using System.Security.Claims;
using Newtonsoft.Json;

namespace Oberon.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryAPIProductos repo;
        public HomeController(IRepositoryAPIProductos repo)
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
        public async Task<IActionResult> Tienda(String tipo)
        {
            List<Producto> productos = await repo.GetProductos();
            List<String> categorias = new List<String>();
            foreach (Producto p in productos)
            {
                categorias.Add(p.Tipo);
            }
            ViewBag.Tipos = categorias.Distinct().ToList();
            if (tipo != null)
            {
                productos = await repo.GetProductos(tipo);
                ViewBag.Tipo = tipo;
            }
            return View(productos);
        }

        //public IActionResult Producto(int id_producto)
        //{
        //    Producto producto = repo.GetProducto(id_producto);
        //    List<Talla> tallas = repo.GetTallasProducto(id_producto);
        //    ViewBag.Tallas = tallas;
        //    ProductoTalla pro = new ProductoTalla(producto, tallas);
        //    return View(pro);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Producto(int id_producto, int id_talla, int unidades)
        //{

        //    Producto producto = repo.GetProducto(id_producto);
        //    List<Talla> tallas = repo.GetTallasProducto(id_producto);
        //    ViewBag.Tallas = tallas;
        //    ProductoTalla pro = new ProductoTalla(producto, tallas);

        //    List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
        //    Talla talla = repo.GetTalla(id_talla);

        //    Carro productoCarro = new Carro(producto, talla, unidades);
        //    if (carro != null)
        //    {
        //        if (carro.Exists(prod => prod.Talla.Id_Producto == id_producto && prod.Talla.Size == productoCarro.Talla.Size))
        //        {
        //            foreach (Carro c in carro)
        //            {
        //                if (c.Talla.Id_Producto == id_producto && c.Talla.Size == productoCarro.Talla.Size)
        //                {
        //                    int unidadesT = c.unidades + productoCarro.unidades;
        //                    if (c.Talla.Stock >= unidadesT)
        //                    {
        //                        c.unidades = unidadesT;
        //                        HttpContext.Session.SetObject<List<Carro>>("carro", carro);
        //                    }
        //                    else
        //                    {
        //                        ViewBag.Mensaje = "No puedes comprar mas de " + c.Talla.Stock + " de esta talla.";
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            carro.Add(productoCarro);
        //            HttpContext.Session.SetObject<List<Carro>>("carro", carro);
        //            HttpContext.Session.SetInt32("carritoCount", carro.Count());
        //        }
        //    }
        //    else
        //    {
        //        List<Carro> carronuevo = new List<Carro>();
        //        carronuevo.Add(productoCarro);
        //        HttpContext.Session.SetObject<List<Carro>>("carro", carronuevo);
        //        HttpContext.Session.SetInt32("carritoCount", carronuevo.Count());
        //    }

        //    return View(pro);
        //}
        //public IActionResult Carrito(int? id_talla)
        //{
        //    List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
        //    if (id_talla != null)
        //    {
        //        Carro c = carro.Find(x => x.Talla.Id_Talla == id_talla);
        //        carro.Remove(c);
        //        HttpContext.Session.SetObject<List<Carro>>("carro", carro);
        //        HttpContext.Session.SetInt32("carritoCount", carro.Count());
        //    }
        //    if (carro != null)
        //    {
        //        double total = 0;
        //        foreach (Carro c in carro)
        //        {
        //            total += c.Producto.Precio * c.unidades;
        //        }
        //        ViewBag.Total = total;
        //    }
        //    ViewBag.Mensaje = HttpContext.Session.GetString("pedido");
        //    HttpContext.Session.Remove("pedido");
        //    return View(carro);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Carrito(List<int> id_talla, List<int> unidades)
        //{
        //    List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
        //    for (int i = 0; i < id_talla.Count(); i++)
        //    {
        //        Carro c = carro.Find(x => x.Talla.Id_Talla == id_talla[i]);
        //        if (c != null)
        //        {
        //            c.unidades = unidades[i];
        //        }
        //    }
        //    HttpContext.Session.SetObject<List<Carro>>("carro", carro);
        //    double total = 0;
        //    foreach (Carro c in carro)
        //    {
        //        total += c.Producto.Precio * c.unidades;
        //    }
        //    ViewBag.Total = total;
        //    return View(carro);
        //}
        //public IActionResult AñadirPedido()
        //{
        //    List<Carro> carro = HttpContext.Session.GetObject<List<Carro>>("carro");
        //    Usuario user = repo.ExisteUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        //    if (carro != null)
        //    {
        //        double precioTotal = 0;
        //        List<ProductoPedido> productos = new List<ProductoPedido>();
        //        foreach (Carro c in carro)
        //        {
        //            ProductoPedido p = new ProductoPedido(c.Talla.Id_Talla, c.unidades);
        //            productos.Add(p);
        //            precioTotal += Math.Round(c.Producto.Precio * c.unidades, 2);
        //        }
        //        Pedido pe = repo.RegistrarPedido(user.Id_Usuario, precioTotal);
        //        foreach (ProductoPedido pro in productos)
        //        {
        //            pro.id_Pedido = pe.id_pedido;
        //            repo.RegistrarProductoPedido(pro);
        //        }
        //    }
        //    HttpContext.Session.Remove("carro");
        //    HttpContext.Session.Remove("carritoCount");
        //    HttpContext.Session.SetString("pedido", "Hemos actualizado tus pedidos! Gracias por confiar en nosotros <3");

        //    return RedirectToAction("Carrito", "Home");
        //}


        //AJAX PAGINATION
    }
}