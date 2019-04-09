
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIProductosPedido : IRepositoryAPIProductosPedido
    {
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;
        public RepositoryAPIProductosPedido()
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
        public async Task<ProductoPedido> GetProductoPedido(int id_producto, string token)
        {
            ProductoPedido productoPedido = await this.CallApi<ProductoPedido>("api/ProductoPedido/"+id_producto, token);
            return productoPedido;
        }

        public async Task<List<ProductoPedido>> GetProductosPedido(int id_pedido, string token)
        {
            List<ProductoPedido> productosPedido = await this.CallApi<List<ProductoPedido>>("api/ProductosPedido/" + id_pedido, token);
            return productosPedido;
        }
        public async Task<List<ProductoPedido>> GetProductosPedidos(string token)
        {
            List<ProductoPedido> productosPedido = await this.CallApi<List<ProductoPedido>>("api/ProductosPedido/", token);
            return productosPedido;
        }
        public async Task<String> RegistrarProductoPedido(ProductoPedidoDTO pro, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);
                cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await cliente.PostAsJsonAsync("api/ProductosPedido/", pro);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<String>();
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}
