using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Models
{
    public class Deportivo: ICoche
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int VelocidadMaxima { get; set; }
        public int VelocidadActual { get; set; }

        public Deportivo(string marca, string modelo, string imagen, int velocidadMaxima, int velocidadActual)
        {
            Marca = marca;
            Modelo = modelo;
            Imagen = imagen;
            VelocidadMaxima = velocidadMaxima;
            VelocidadActual = velocidadActual;
        } 

        public Deportivo()
        {
            Marca = "Murcielago";
            Modelo = "Lambo";
            Imagen = "3.jpg";
            VelocidadMaxima = 300;
            VelocidadActual = 0;
        }

        public void Acelerar()
        {
            this.VelocidadActual += 40;
            if (this.VelocidadActual > this.VelocidadMaxima) this.VelocidadActual = this.VelocidadMaxima;
        }
        public void Frenar()
        {
            this.VelocidadActual -= 40;
            if (this.VelocidadActual < 0) this.VelocidadActual = 0;
        }
    }
}
