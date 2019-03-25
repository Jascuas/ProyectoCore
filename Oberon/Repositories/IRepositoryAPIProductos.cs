using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Repositories
{
    public interface IRepositoryAPIProductos
    {
        Task<List<Producto>> GetProductos();
        Task<List<Producto>> GetProductos(String tipo);
        Task<Producto> GetProducto(int id_producto);
        Task<Producto> GetProductoFromTalla(int id_talla);
    }
}
