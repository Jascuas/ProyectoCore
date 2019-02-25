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
        public Carro(Producto producto,Talla talla, int unidades)
        {
            this.Producto = producto;
            this.Talla = talla;
            this.unidades = unidades;
        }
        public Talla Talla { get; set; }
        public Producto Producto { get; set; }
        public int unidades { get; set; }
        
    }
}
