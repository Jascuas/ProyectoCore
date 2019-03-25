
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oberon.Data;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIPedidos : IRepositoryAPIPedidos
    {
        public async Task<Pedido> GetPedido(int id_pedido, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pedido>> GetPedidos(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pedido>> GetPedidos(int id_usurio, string token)
        {
            throw new NotImplementedException();
        }

        public async Task RegistrarPedido(Pedido pedido, string token)
        {
            throw new NotImplementedException();
        }
    }
}
