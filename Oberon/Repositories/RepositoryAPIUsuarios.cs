using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oberon.Models;

namespace Oberon.Repositories
{
    public class RepositoryAPIUsuarios : IRepositoryAPIUsuarios
    {
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;

        public RepositoryAPIUsuarios()
        {
            this.uriapi = "https://apioberon.azurewebsites.net/";
            this.headerjson = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<String> GetToken(LoginCredentials credentials)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "login";
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                FormUrlEncodedContent content =
                    new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", credentials.Identifier),
                        new KeyValuePair<string, string>("password", credentials.Password)
                    });
                HttpResponseMessage response = await
                client.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    String contenido = await
                    response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(contenido);
                    String token = json.GetValue("access_token").ToString();
                    return token;
                }
                else
                {
                    return null;
                }

            }
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
        public async Task<Object> ExisteUsuario(LoginCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ExisteUsuario(int id_usuario)
        {
            throw new NotImplementedException();
        }
        public async Task<Usuario> LoginUsuario(LoginCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public async Task RegistrarUsuario(RegisterCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> Usuarios(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> GetPedido(int id_pedido, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pedido>> GetPedidos(int id_usurio, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductoPedido> GetProductoPedido(int id_producto, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductoPedido>> GetProductosPedido(int id_pedido, string token)
        {
            throw new NotImplementedException();
        }


    }
}
