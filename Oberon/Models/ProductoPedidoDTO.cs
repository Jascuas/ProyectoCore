using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class ProductoPedidoDTO
    {
        public ProductoPedidoDTO(int? id_Producto_Pedido, int? id_Pedido, int? id_Producto, string size, int unidades)
        {
            Id_Producto_Pedido = id_Producto_Pedido;
            Id_Pedido = id_Pedido;
            Id_Producto = id_Producto;
            Size = size;
            Unidades = unidades;
        }

        public int? Id_Producto_Pedido { get; set; }
        public int? Id_Pedido { get; set; }
        public int? Id_Producto { get; set; }
        public String Size { get; set; }
        public int Unidades { get; set; }
    }
}
