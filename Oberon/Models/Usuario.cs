using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Usuario { get; set; }
        [Column("PASSWORD")]
        public String Password { get; set; }
        [Column("NOMBRE_USUARIO")]
        public String User { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("APELLIDOS")]
        public String Apellidos { get; set; }
        [Column("EMAIL")]
        public String Email { get; set; }
        [Column("ROLE")]
        public String Rol { get; set; }
        [Column("FECHA_REGISTRO")]
        public DateTime Fecha_Registro { get; set; }
        public Usuario(string password, string user, string nombre, string apellidos, string email)
        {
            Password = password;
            User = user;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
        }
    }
}
