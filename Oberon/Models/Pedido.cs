using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        public Pedido(int id_Usuario, DateTime fecha_Pedido, double total)
        {
            this.id_Usuario = id_Usuario;
            this.fecha_Pedido = fecha_Pedido;
            this.total = total;
        }

        [Key]
        [Column("Id_Pedido")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_pedido { get; set; }
        [Column("Id_Usuario")]
        public int id_Usuario { get; set; }
        [Column("Fecha_Pedido")]
        public DateTime fecha_Pedido { get; set; }
        [Column("Total")]
        public double total { get; set; }
        
    }
}
