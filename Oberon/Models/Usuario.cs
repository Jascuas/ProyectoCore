using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public String User { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Email { get; set; }
        public DateTime Fecha { get; set; }
        public String Rol { get; set; }
    }
}
