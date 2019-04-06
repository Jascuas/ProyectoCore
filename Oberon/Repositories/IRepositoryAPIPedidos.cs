using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Repositories
{
    public interface IRepositoryAPIPedidos
    {
        Task<Pedido> GetPedido(int id_pedido, String token);
        Task<List<Pedido>> GetPedidos(String token);
        Task<List<Pedido>> GetPedidos(int id_usurio, String token);
        Task<Pedido> RegistrarPedido(Pedido pedido, String token);
    }


}
