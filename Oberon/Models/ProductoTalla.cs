using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class ProductoTalla
    {
        public ProductoTalla(Producto producto, List<Talla> tallas)
        {
            this.producto = producto;
            this.tallas = tallas;
            this.stock = generarStock();
        }
        public ProductoTalla(Producto producto, Talla talla, int cantidad)
        {
            this.producto = producto;
            this.talla = talla;
            this.cantidad = cantidad;
        }
        public Producto producto { get; set; }
        public List<Talla> tallas { get; set; }
        public int stock { get; set; }
        public int cantidad { get; set; }
        public Talla talla { get; set; }

        public int generarStock()
        {
            foreach (Talla t in tallas)
            {
                this.stock += t.Stock;
            }
            return stock;
        }
        
    }
}
