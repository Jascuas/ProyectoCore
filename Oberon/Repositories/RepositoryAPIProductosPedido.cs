
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oberon.Data;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIProductosPedido : IRepositoryAPIProductosPedido
    {
        public async Task<ProductoPedido> GetProductoPedido(int id_producto, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductoPedido>> GetProductosPedido(int id_pedido, string token)
        {
            throw new NotImplementedException();
        }

        public async Task RegistrarProductoPedido(ProductoPedido pro, string token)
        {
            throw new NotImplementedException();
        }
    }
}
