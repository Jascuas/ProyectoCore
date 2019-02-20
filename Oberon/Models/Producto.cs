using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    [Table("PRODUCTOS")]
    public class Producto 
    {
        [Key]
        [Column("ID_PRODUCTO")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Producto { get; set; }
        [Column("PRODUCTO")]
        public String Nombre { get; set; }
        [Column("COLOR")]
        public String Color { get; set; }
        [Column("TIPO")]
        public String Tipo { get; set; }

        [Column("PRECIO")]
        public double Precio { get; set; }
        [Column("INFORMACION")]
        public String Informacion { get; set; }
        [Column("IMAGEN")]
        public String Imagen { get; set; }
        [Column("ESTADO")]
        public String Estado { get; set; }
        [Column("DETALLES")]
        public String Detalles { get; set; }
        public Producto(string nombre, string color, string tipo, double precio, string informacion, string imagen, string estado, string detalles)
        {
            Nombre = nombre;
            Color = color;
            Tipo = tipo;
            Precio = precio;
            Informacion = informacion;
            Imagen = imagen;
            Estado = estado;
            Detalles = detalles;
        }
    }
}
