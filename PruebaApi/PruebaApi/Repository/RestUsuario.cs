using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PruebaApi.Model;

namespace PruebaApi.Repository
{
    public class RestUsuario : IRestUsuario
    {
        HttpClient Cliente;
        string Controlador;
        List<UsuarioModel> ListaItems { get; set; }

        public RestUsuario()
        {
            Cliente = new HttpClient();
            Controlador = "usuarios/";
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Servidor.URL+ Controlador+id, string.Empty));

            try
            {
                var response = await Cliente.DeleteAsync(uri);
            }
            catch (Exception ex)
            {           
            }
        }

        public async Task GuardarItem(UsuarioModel item, bool isNewItem)
        {
            var uri = new Uri(string.Format(Servidor.URL+Controlador, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await Cliente.PostAsync(uri, content);
                }
                else
                {
                    var uri2 = new Uri(string.Format(Servidor.URL + Controlador+"/"+item.Id, string.Empty));
                    response = await Cliente.PutAsync(uri2, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<List<UsuarioModel>> ObtenerItems()
        {
            ListaItems = new List<UsuarioModel>();

            var uri = new Uri(string.Format(Servidor.URL+Controlador, string.Empty));
            try
            {
                var response = await Cliente.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ListaItems = JsonConvert.DeserializeObject<List<UsuarioModel>>(content);
                }
            }
            catch (Exception ex)
            {
            }

            return ListaItems;
        }
    }
}
