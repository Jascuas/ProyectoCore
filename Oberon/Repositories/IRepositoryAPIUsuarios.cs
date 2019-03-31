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
        Task<String> GetToken(LoginCredentials credentials);
        Task<Usuario> GetUsuario(String token);
        Task<String> RegistrarUsuario(RegisterCredentials credentials);
        //Task<List<Usuario>> Usuarios(String token);
        Task<Pedido> GetPedido(int id_usuario, int id_pedido, String token);
        Task<List<Pedido>> GetPedidos(int id_usuario, String token);
        Task<ProductoPedido> GetProductoPedido(int id_usuario, int id_pedido, int id_producto, String token);
        Task<List<ProductoPedido>> GetProductosPedido(int id_usuario, int id_pedido, String token);
        
    }
}
