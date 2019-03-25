using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class RegisterCredentials
    {
        public RegisterCredentials(string nombre, string apellidos, string email, string password, string passwordConfirm)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }

        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PasswordConfirm { get; set; }
    }
}
