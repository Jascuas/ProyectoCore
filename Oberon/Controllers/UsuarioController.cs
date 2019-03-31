using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;
using Microsoft.AspNetCore.Http;
namespace Oberon.Controllers
{
    public class UsuarioController : Controller
    {
        IRepositoryAPIUsuarios repo;
        public UsuarioController(IRepositoryAPIUsuarios repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Perfil()
        {
            Usuario user = await repo.GetUsuario(HttpContext.Session.GetString("token"));
            return View(user);
        }
        public async Task<IActionResult> Pedidos()
        {
            String token = HttpContext.Session.GetString("token");
            Usuario user = await repo.GetUsuario(token);
            List<Pedido> pedidos = await repo.GetPedidos(user.Id_Usuario, token);
            ViewBag.Pedidos = pedidos;
            return View(user);
        }
        public async Task<IActionResult> ProductosPedido(int id_pedido)
        {
            String token = HttpContext.Session.GetString("token");
            Usuario user = await repo.GetUsuario(token);
            Pedido pedido = await repo.GetPedido(user.Id_Usuario, id_pedido, token);
            List<ProductoPedido> productosPedido = await repo.GetProductosPedido(user.Id_Usuario, id_pedido, token);
            ViewBag.Productos = productosPedido;
            ViewBag.Pedido = pedido;
            return View(user);
        }
    }
}