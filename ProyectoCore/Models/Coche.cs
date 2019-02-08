using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Models
{
    public class Coche: ICoche
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int VelocidadMaxima { get; set; }
        public int VelocidadActual{ get; set; }

        public Coche()
        {
            Marca = "Wolf";
            Modelo = "Lunar";
            Imagen = "1.jpg";
            VelocidadMaxima = 100;
            VelocidadActual = 0;
        }
        public void Acelerar()
        {
            this.VelocidadActual += 20;
            if (this.VelocidadActual > this.VelocidadMaxima) this.VelocidadActual = this.VelocidadMaxima;
        }
        public void Frenar()
        {
            this.VelocidadActual -= 20;
            if (this.VelocidadActual < 0) this.VelocidadActual = 0;
        }
    }
}
