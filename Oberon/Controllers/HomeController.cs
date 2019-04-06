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
        IRepositoryAPIProductos repoProductos;
        IRepositoryAPIPedidos repoPedidos;
        IRepositoryAPIProductosPedido repoProductosPedido;
        public HomeController(IRepositoryAPIProductos repoProductos, IRepositoryAPIPedidos repoPedidos, IRepositoryAPIProductosPedido repoProductosPedido)
        {
            this.repoProductos = repoProductos;
            this.repoPedidos = repoPedidos;
            this.repoProductosPedido = repoProductosPedido;
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
            List<Producto> productos = await repoProductos.GetProductos();
            List<String> categorias = new List<String>();
            foreach (Producto p in productos)
            {
                categorias.Add(p.Tipo);
            }
            ViewBag.Tipos = categorias.Distinct().ToList();
            if (tipo != null)
            {
                productos = await repoProductos.GetProductos(tipo);
                ViewBag.Tipo = tipo;
            }
            return View(productos);
        }
        public async Task<IActionResult> Producto(int id_producto)
        {
            Producto producto = await repoProductos.GetProducto(id_producto);
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Producto(int id_producto, String size, int unidades)
        {

            Producto producto = await repoProductos.GetProducto(id_producto);
            ProductoPedido productoPedido = new ProductoPedido(producto, size, unidades);
            List<ProductoPedido> carro = HttpContext.Session.GetObject<List<ProductoPedido>>("carro");
            if (carro != null)
            {
                ProductoPedido pro = carro.Find(prod => prod.Producto.Id_Producto == id_producto && prod.Size == size) as ProductoPedido;
                if (pro != null)
                {
                    carro.Find(p =>p == pro).Unidades +=unidades;
                    HttpContext.Session.SetObject<List<ProductoPedido>>("carro", carro);
                }
                else
                {
                    carro.Add(productoPedido);
                    HttpContext.Session.SetObject<List<ProductoPedido>>("carro", carro);
                    HttpContext.Session.SetInt32("carritoCount", carro.Count());
                }
            }
            else
            {
                carro = new List<ProductoPedido>();
                carro.Add(productoPedido);
                HttpContext.Session.SetObject<List<ProductoPedido>>("carro", carro);
                HttpContext.Session.SetInt32("carritoCount", carro.Count());
            }

            return View(producto);
        }
        public IActionResult Carrito(int? id)
        {
            List<ProductoPedido> carro = HttpContext.Session.GetObject<List<ProductoPedido>>("carro");
            if (id != null)
            {
                carro.RemoveAt(id.Value);
                HttpContext.Session.SetObject<List<ProductoPedido>>("carro", carro);
                HttpContext.Session.SetInt32("carritoCount", carro.Count());
            }
            if (carro != null)
            {
                double total = 0;
                foreach (ProductoPedido p in carro)
                {
                    total += p.Producto.Precio * p.Unidades;
                }
                ViewBag.Total = total;
            }
            ViewBag.Mensaje = HttpContext.Session.GetString("pedido");
            HttpContext.Session.Remove("pedido");
            return View(carro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Carrito(List<int> id, List<int> unidades)
        {
            List<ProductoPedido> carro = HttpContext.Session.GetObject<List<ProductoPedido>>("carro");
            for (int i = 0; i < id.Count(); i++)
            {
                carro.ElementAt(id[i]).Unidades = unidades[i];
            }
            HttpContext.Session.SetObject<List<ProductoPedido>>("carro", carro);
            double total = 0;
            foreach (ProductoPedido p in carro)
            {
                total += p.Producto.Precio * p.Unidades;
            }
            ViewBag.Total = total;
            return View(carro);
        }
        public async Task<IActionResult> AñadirPedido()
        {
            List<ProductoPedido> carro = HttpContext.Session.GetObject<List<ProductoPedido>>("carro");
            if (carro != null)
            {
                double precioTotal = 0;
                String token = HttpContext.Session.GetString("token");
                foreach (ProductoPedido c in carro)
                {
                    precioTotal += Math.Round(c.Producto.Precio * c.Unidades, 2);
                }
                Pedido pe = new Pedido(int.Parse(User.Identity.Name), precioTotal);
                pe = await repoPedidos.RegistrarPedido(pe, token);
                foreach (ProductoPedido pro in carro)
                {
                    ProductoPedidoDTO p = new ProductoPedidoDTO(null, pe.Id_pedido, pro.Producto.Id_Producto, pro.Size, pro.Unidades);
                    await repoProductosPedido.RegistrarProductoPedido(p, token);
                }
            }
            HttpContext.Session.Remove("carro");
            HttpContext.Session.Remove("carritoCount");
            HttpContext.Session.SetString("pedido", "Hemos actualizado tus pedidos! Gracias por confiar en nosotros <3");
            return RedirectToAction("Carrito", "Home");
        }


        //AJAX PAGINATION
    }
}