﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class Producto 
    {
        public int Id_Producto { get; set; }
        public String Nombre { get; set; }
        public String Tipo { get; set; }
        public String Estado { get; set; }
        public double Precio { get; set; }
        public String Imagen { get; set; }
        public List<Talla> Tallas { get; set; }
        public String Detalles { get; set; }
        public String Informacion { get; set; }
    }
}
