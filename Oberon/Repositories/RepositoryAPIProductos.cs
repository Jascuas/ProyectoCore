
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIProductos : IRepositoryAPIProductos
    {
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;
        public RepositoryAPIProductos()
        {
            this.uriapi = "https://apioberon.azurewebsites.net/";
            this.headerjson = new MediaTypeWithQualityHeaderValue("application/json");
        }
        private async Task<T> CallApi<T>(String peticion, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);
                if (token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                HttpResponseMessage response = await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    T datos = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<Producto> GetProducto(int id_producto)
        {
            Producto producto = await this.CallApi<Producto>("api/Productos/"+ id_producto, null);
            return producto;
        }

        public async Task<Producto> GetProductoFromTalla(int id_talla)
        {
            Producto producto = await this.CallApi<Producto>("api/Productos/" + id_talla, null);
            return producto;
        }

        public async Task<List<Producto>> GetProductos()
        {
            List<Producto> productos = await this.CallApi<List<Producto>>("api/Productos/", null);
            return productos;
        }

        public async Task<List<Producto>> GetProductos(string tipo)
        {
            List<Producto> productos = await this.CallApi<List<Producto>>("api/Productos/"+tipo, null);
            return productos;
        }
    }
}
