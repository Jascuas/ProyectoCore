using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class ProductoPedido
    {
        public Producto Producto { get; set; }
        public String Size { get; set; }
        public int Unidades { get; set; }

    }
}
