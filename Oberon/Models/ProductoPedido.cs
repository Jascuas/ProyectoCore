using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    [Table("Productos_Pedido")]
    public class ProductoPedido
    {
        public ProductoPedido(int id_Talla, int unidades)
        {
            this.id_Talla = id_Talla;
            this.unidades = unidades;
        }
        //public ProductoPedido(int id_Pedido, int id_Talla, int unidades)
        //{
        //    this.id_Pedido = id_Pedido;
        //    this.id_Talla = id_Talla;
        //    this.unidades = unidades;
        //}
        [Key]
        [Column("Id_Producto_Pedido")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Producto_Pedido { get; set; }
        [Column("Id_Pedido")]
        public int id_Pedido { get; set; }
        [Column("Id_Talla")]
        public int id_Talla { get; set; }
        [Column("Unidades")]
        public int unidades { get; set; }

    }
}
