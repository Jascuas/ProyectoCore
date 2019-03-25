using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class Talla
    {
        public int Id_Talla { get; set; }
        public int Id_Producto { get; set; }
        public String Size { get; set; }
        public int Stock { get; set; }
    }
}
