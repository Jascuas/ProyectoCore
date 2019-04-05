using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class LoginCredentials
    {
        [Required(ErrorMessage = "Necesita un email o un nombre de usuario valido.")]
        public String Identifier { get; set; }
        [Required(ErrorMessage = "Necesita una contraseña correcta.")]
        public String Password { get; set; }
        public LoginCredentials(string identifier, string password)
        {
            Identifier = identifier;
            Password = password;
        }

        public LoginCredentials()
        {
        }
    }
}
