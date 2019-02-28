
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oberon.Data;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryOberon: IRepositoryOberon
    {
        IOberonContext context;

        public RepositoryOberon(IOberonContext context)
        {
            this.context = context;
        }

        public Usuario ExisteUsuario(String email, String password)
        {
            var consulta = from datos in context.Usuario where datos.Email == email && datos.Password == password select datos;
            return consulta.FirstOrDefault();
        }

        public void RegistrarUsuario(String password, String nombre, String apellidos, String email)
        {
            String user = nombre + " " + apellidos;
            DateTime fecha = DateTime.Now;
            String rol = "cliente";
            Usuario u = new Usuario(password, user, nombre, apellidos, email, rol, fecha);
            this.context.Usuario.Add(u);
            this.context.SaveChanges();
        }
        public List<Producto> GetProductos()
        {
            var consulta = from datos in context.Producto select datos;
            return consulta.ToList();
        }
        public List<Producto> GetProductos(String tipo)
        {
            var consulta = from datos in context.Producto where datos.Tipo == tipo select datos;
            return consulta.ToList();
        }
        public Producto GetProducto(int id_producto)
        {
            var consulta = from datos in context.Producto where datos.Id_Producto == id_producto select datos;
            return consulta.FirstOrDefault();
        }

        public Talla GetTalla(int id_talla)
        {
            var consulta = from datos in context.Talla where datos.Id_Talla == id_talla select datos;
            return consulta.FirstOrDefault();
        }

        public List<Talla> GetTallasProducto(int id_producto)
        {
            var consulta = from datos in context.Talla where datos.Id_Producto == id_producto select datos;
            return consulta.ToList();
        }

        public List<Talla> GetTallas()
        {
            var consulta = from datos in context.Talla select datos;
            return consulta.ToList();
        }

        public Usuario ExisteUsuario(int id_usuario)
        {
            var consulta = from datos in context.Usuario where datos.Id_Usuario == id_usuario select datos;
            return consulta.FirstOrDefault();
        }

        public Pedido GetPedido(int id_pedido)
        {
            var consulta = from datos in context.Pedidos where datos.id_pedido == id_pedido select datos;
            return consulta.FirstOrDefault();
        }

        public List<Pedido> GetPedidos(int id_usurio)
        {
            var consulta = from datos in context.Pedidos where datos.id_Usuario == id_usurio select datos;
            return consulta.ToList();
        }

        public ProductoPedido GetProductoPedido(int id_producto)
        {
            var consulta = from datos in context.ProductosPedido where datos.id_Producto_Pedido == id_producto select datos;
            return consulta.FirstOrDefault();
        }

        public List<ProductoPedido> GetProductosPedido(int id_pedido)
        {
            var consulta = from datos in context.ProductosPedido where datos.id_Pedido == id_pedido select datos;
            return consulta.ToList();
        }

        public Pedido RegistrarPedido(int id_Usuario, double total)
        {
            DateTime fecha = DateTime.Now;
            Pedido p = new Pedido(id_Usuario, fecha, total);
            this.context.Pedidos.Add(p);
            this.context.SaveChanges();
            return p;
        }

        public void RegistrarProductoPedido(ProductoPedido pro)
        {
            this.context.ProductosPedido.Add(pro);
            this.context.SaveChanges();
        }
    }
}
