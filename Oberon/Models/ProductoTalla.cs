using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Models
{
    public class ProductoTalla
    {
        public ProductoTalla(Producto producto, List<Talla> tallas)
        {
            this.producto = producto;
            this.tallas = tallas;
            this.html = generarHtml();
        }

        public Producto producto { get; set; }
        public List<Talla> tallas { get; set; }
        public int stock { get; set; }
        public String html { get; set; }

        public String generarHtml()
        {
            String html = "<select class='browser-default  custom-select-sm'>";
            foreach (Talla t in tallas)
            {
                this.stock += t.Stock;
                if (tallas.Count() > 1)
                {
                    if (t.Stock == 0)
                    {
                        html += "<option value = '" + t.Size + "'data-toggle='tooltip' data-placement='right' title='Disponibles: " + t.Stock + "' disabled>" + t.Size + "- Agotada</ option >";
                    }
                    else
                        html += "<option value = '" + t.Size + "'data-toggle='tooltip' data-placement='right' title='Disponibles: " + t.Stock + "'>" + t.Size + "</ option >";
                }
                else
                {
                    html += "<option selected value='" + t.Size + "'>Talla unica";
                }
            }
            html += "</select>";
            return html;
        }
    }
}
