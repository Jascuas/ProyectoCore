﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class ProductoPedido
    {
        public ProductoPedido(Producto producto, string size, int unidades)
        {
            Producto = producto;
            Size = size;
            Unidades = unidades;
        }
        public int? Id_Producto_Pedido { get; set; }
        public int? Id_Pedido { get; set; }
        public Producto Producto { get; set; }
        public String Size { get; set; }
        public int Unidades { get; set; }
    }
}
