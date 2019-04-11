using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;

namespace Oberon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        IRepositoryAPIProductos repoProductos;
        IRepositoryAPIPedidos repoPedidos;
        IRepositoryAPIProductosPedido repoProductosPedido;
        IRepositoryAPIUsuarios repo;
        public HomeController(IRepositoryAPIUsuarios repo, IRepositoryAPIProductos repoProductos, IRepositoryAPIPedidos repoPedidos, IRepositoryAPIProductosPedido repoProductosPedido)
        {
            this.repo = repo;
            this.repoProductos = repoProductos;
            this.repoPedidos = repoPedidos;
            this.repoProductosPedido = repoProductosPedido;
        }
        public async Task<IActionResult> Index()
        {
            String token = HttpContext.Session.GetString("token");
            Usuario user = await repo.GetUsuario(token);
            return View(user);
        }
        public async Task<IActionResult> ModificarProductos()
        {
            List<Producto> productos = await repoProductos.GetProductos();
            return View(productos);
        }
        [HttpPut]
        public async Task<IActionResult> ModificarProductos(Producto producto)
        {
            String token = HttpContext.Session.GetString("token");
            List<Producto> productos = await repoProductos.GetProductos();
            return View(productos);
        }
        public async Task<IActionResult> ModificarUsuarios()
        {
            String token = HttpContext.Session.GetString("token");
            List<Usuario> usuarios = await repo.GetUsuarios(token);
            return View(usuarios);
        }
        [HttpPut]
        public async Task<IActionResult> ModificarUsuarios(Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            String token = HttpContext.Session.GetString("token");
            String mesaje = await this.repo.ModificarUsuario(user, token);
            List<Usuario> usuarios = await repo.GetUsuarios(token);
            ViewBag.Mensaje = mesaje;
            return View(usuarios);
        }
        public async Task<IActionResult> ShowStock()
        {
            List<Producto> productos = await repoProductos.GetProductos();
            return View(productos);
        }
        public async Task<IActionResult> Sells()
        {
            String token = HttpContext.Session.GetString("token");
            List<Pedido> pedidos = await repoPedidos.GetPedidos(token);
            ViewBag.Pedidos = pedidos;
            List<ProductoPedido> productos = await repoProductosPedido.GetProductosPedidos(token);
            List<ProductoPedido> productosTotal = new List<ProductoPedido>();
            Boolean añadir = true;
            foreach (ProductoPedido p in productos)
            {
                añadir = true;
                foreach(ProductoPedido pro in productosTotal)
                {
                    if(p.Producto.Id_Producto == pro.Producto.Id_Producto && p.Size == pro.Size)
                    {
                        pro.Unidades += p.Unidades;
                        añadir = false;
                    }
                }
                if (añadir) productosTotal.Add(p);
            }
            return View(productosTotal);
        }
    }
}