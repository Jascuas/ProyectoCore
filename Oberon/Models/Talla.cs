using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    [Table("Tallas")]
    public class Talla
    {
        public Talla(int id_Talla, int id_Producto, string size, int stock)
        {
            Id_Talla = id_Talla;
            Id_Producto = id_Producto;
            Size = size;
            Stock = stock;
        }

        [Key]
        [Column("Id_Talla")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Talla { get; set; }
        [Column("Id_Producto")]
        public int Id_Producto { get; set; }
        [Column("Talla")]
        public String Size { get; set; }
        [Column("Stock")]
        public int Stock { get; set; }
        
    }
}
