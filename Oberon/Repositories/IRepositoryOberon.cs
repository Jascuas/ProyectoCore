using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Repositories
{
    public interface IRepositoryOberon
    {
        Usuario ExisteUsuario(String email, String password);
        Usuario ExisteUsuario(int id_usuario);
        void RegistrarUsuario(String password, String nombre, String apellidos, String email);
        List<Producto> GetProductos();
        List<Producto> GetProductos(String tipo);
        Producto GetProducto(int id_producto);
        Talla GetTalla(int id_talla);
        List<Talla> GetTallasProducto(int id_producto);
        List<Talla> GetTallas();
        Pedido GetPedido(int id_pedido);
        List<Pedido> GetPedidos(int id_usurio);
        ProductoPedido GetProductoPedido(int id_producto);
        List<ProductoPedido> GetProductosPedido(int id_pedido);
        Pedido RegistrarPedido(int id_Usuario, double total);
        void RegistrarProductoPedido(ProductoPedido pro);
    }
}
