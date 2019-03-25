using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Repositories
{
    public interface IRepositoryAPIUsuarios
    {
        Task<IActionResult> ExisteUsuario(LoginCredentials credentials);
        Task<Usuario> LoginUsuario(LoginCredentials credentials);
        Task<Usuario> ExisteUsuario(int id_usuario);
        Task RegistrarUsuario(RegisterCredentials credentials);
        Task<List<Usuario>> Usuarios(String token);
        Task<Pedido> GetPedido(int id_pedido, String token);
        Task<List<Pedido>> GetPedidos(int id_usurio, String token);
        Task<ProductoPedido> GetProductoPedido(int id_producto, String token);
        Task<List<ProductoPedido>>  GetProductosPedido(int id_pedido, String token);
    }
}
