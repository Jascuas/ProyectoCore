
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oberon.Data;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIProductos : IRepositoryAPIProductos
    {
        public async Task<Producto> GetProducto(int id_producto)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> GetProductoFromTalla(int id_talla)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetProductos()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetProductos(string tipo)
        {
            throw new NotImplementedException();
        }
    }
}
