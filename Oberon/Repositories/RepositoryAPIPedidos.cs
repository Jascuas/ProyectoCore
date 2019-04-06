
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIPedidos : IRepositoryAPIPedidos
    {
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;
        public RepositoryAPIPedidos()
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
        public async Task<Pedido> GetPedido(int id_pedido, string token)
        {
            Pedido pedido = await this.CallApi<Pedido>("api/Pedidos/"+id_pedido, token);
            return pedido;
        }

        public async Task<List<Pedido>> GetPedidos(string token)
        {
            List<Pedido> pedidos = await this.CallApi<List<Pedido>>("api/Pedidos/", token);
            return pedidos;
        }

        public async Task<List<Pedido>> GetPedidos(int id_usurio, string token)
        {
            List<Pedido> pedidos = await this.CallApi<List<Pedido>>("api/Pedidos/"+ id_usurio, token);
            return pedidos;
        }

        public async Task<Pedido> RegistrarPedido(Pedido pedido, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);
                cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await cliente.PostAsJsonAsync("api/Pedidos/", pedido);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Pedido>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
