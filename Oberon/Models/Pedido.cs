﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class Pedido
    {
        public int Id_pedido { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public double Total { get; set; }
        
    }
}
