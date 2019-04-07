using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
                String peticion = "recuperartoken";
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                FormUrlEncodedContent content =
                    new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<String, String>("grant_type", "password"),
                        new KeyValuePair<String, String>("username", credentials.Identifier),
                        new KeyValuePair<String, String>("password", credentials.Password)
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
        public async Task<Usuario> GetUsuario(String token)
        {
            Usuario usuario = await this.CallApi<Usuario>("api/Usuario/" , token);
            return usuario;
        }
        public async Task<Usuario> GetUsuario(int id, String token)
        {
            Usuario usuario = await this.CallApi<Usuario>("api/Usuarios/"+id, token);
            return usuario;
        }
        public async Task<List<Usuario>> GetUsuarios(String token)
        {
            List<Usuario> usuarios = await this.CallApi<List<Usuario>>("api/Usuarios/", token);
            return usuarios;
        }
        public async Task<String> RegistrarUsuario(RegisterCredentials credentials)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);
                
                HttpResponseMessage response = await cliente.PostAsJsonAsync("api/Usuarios/", credentials);
                if (response.IsSuccessStatusCode)
                {
                    return "Registrado correctamente, pruebe a loguearse";
                }
                else
                {
                    return "No hemos podido registrarle, pruebe otra vez";
                }
            }
        }
        public async Task<String> ModificarUsuario(Usuario user, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);
                cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await cliente.PutAsJsonAsync("api/Usuarios/", user);
                if (response.IsSuccessStatusCode)
                {
                    return "Modificaciones realizadas exitosamente";
                }
                else
                {
                    return "No hemos podido modificarle, pruebe otra vez";
                }
            }
        }
        public async Task<Pedido> GetPedido(int id_usuario, int id_pedido, String token)
        {
            Pedido pedido = await this.CallApi<Pedido>("api/Usuarios/"+id_usuario+"/Pedidos/"+id_pedido, token);
            return pedido;
        }
        public async Task<List<Pedido>> GetPedidos(int id_usuario, String token)
        {
            List<Pedido> pedidos = await this.CallApi<List<Pedido>>("api/Usuarios/" + id_usuario + "/Pedidos/", token);
            return pedidos;
        }
        public async Task<ProductoPedido> GetProductoPedido(int id_usuario, int id_pedido, int id_producto, String token)
        {
            ProductoPedido producto = await this.CallApi<ProductoPedido>("api/Usuarios/" + id_usuario + "/Pedidos/"+id_pedido+ "/ProductosPedido/" + id_producto, token);
            return producto;
        }
        public async Task<List<ProductoPedido>> GetProductosPedido(int id_usuario, int id_pedido, String token)
        {
            List<ProductoPedido> productos = await this.CallApi<List<ProductoPedido>>("api/Usuarios/" + id_usuario + "/Pedidos/" + id_pedido + "/ProductosPedido/", token);
            return productos;
        }


    }
}
