using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Repositories
{
    public interface IRepositoryAPIProductosPedido
    {
        Task<ProductoPedido> GetProductoPedido(int id_producto, String token);
        Task<List<ProductoPedido>>  GetProductosPedido(int id_pedido, String token);
        Task<List<ProductoPedido>> GetProductosPedidos(String token);
        Task<String> RegistrarProductoPedido(ProductoPedidoDTO pro, String token);
    }
}
