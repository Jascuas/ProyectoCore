using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;

namespace Oberon.Controllers
{
    public class UsuarioController : Controller
    {
        //IRepositoryOberon repo;
        //public UsuarioController(IRepositoryOberon repo)
        //{
        //    this.repo = repo;
        //}
        //public IActionResult Perfil()
        //{
        //    Usuario user = repo.ExisteUsuario(int.Parse( HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        //    return View(user);
        //}
        //public IActionResult Pedidos()
        //{
        //    Usuario user = repo.ExisteUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        //    List<Pedido> pedidos = repo.GetPedidos(user.Id_Usuario);
        //    ViewBag.Pedidos = pedidos;
        //    return View(user);
        //}
        //public IActionResult ProductosPedido(int id_pedido)
        //{
        //    Usuario user = repo.ExisteUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        //    Pedido pedido = repo.GetPedido(id_pedido);
        //    List<ProductoPedido> productosPedido = repo.GetProductosPedido(pedido.id_pedido);
        //    List<Carro> productos = new List<Carro>();
        //    foreach (ProductoPedido pro in productosPedido)
        //    {
        //        Talla t = repo.GetTalla(pro.id_Talla);
        //        Producto p = repo.GetProducto(t.Id_Producto);
        //        Carro c = new Carro(p, t, pro.unidades);
        //        productos.Add(c);
        //    }
        //    ViewBag.Productos = productos;
        //    ViewBag.Pedido = pedido;
        //    return View(user);
        //}
    }
}