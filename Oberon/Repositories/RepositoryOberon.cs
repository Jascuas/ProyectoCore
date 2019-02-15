
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
    }
}
