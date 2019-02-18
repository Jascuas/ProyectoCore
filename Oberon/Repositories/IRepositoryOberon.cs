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
        void RegistrarUsuario(String password, String nombre, String apellidos, String email);
        List<Producto> GetProductos();
        List<Producto> GetProductos(String tipo);
        Producto GetProducto(int id_producto);
        
    }
}
