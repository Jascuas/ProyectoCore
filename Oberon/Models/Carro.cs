using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class Carro
    {
        public Carro(List<ProductoCarro> productos)
        {
            this.Productos = productos;
        }
        public List<ProductoCarro> Productos { get; set; }
        
    }
}
