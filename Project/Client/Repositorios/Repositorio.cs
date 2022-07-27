using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Project.Shared.Entidades;
//using Project.Shared.PrudenciaDTOs;
//using Project.Shared.Models;

using Newtonsoft.Json;

namespace Project.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
      
        
        //private JsonSerializerSettings OpcionesPorDefectoJSON =>
        //    new JsonSerializerSettings() { PropertyNameCaseInsensitive = true };


        protected JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
        };
        public async Task<HttpResponseWrapper<T>>Get<T>(string url)
        {
                var responseHTTP = await httpClient.GetAsync(url);
              
           
            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHTTP, JsonSettings);
                return new HttpResponseWrapper<T>(response, false, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            Console.WriteLine(url);
            //var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarJSON = JsonConvert.SerializeObject(enviar, JsonSettings);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {

           

        url =  "https://localhost:44302/" +url;
            Console.WriteLine(url);

           
            //var enviarJSON = JsonSerializer.Serialize(enviar, JsonOptions);
            var enviarJSON = JsonConvert.SerializeObject(enviar, JsonSettings);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                Console.WriteLine("ok");
                var response = await DeserializarRespuesta<TResponse>(responseHttp, JsonSettings);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                Console.WriteLine("Error");
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            //var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarJSON = JsonConvert.SerializeObject(enviar, JsonSettings);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

     

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerSettings settings)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            //var a = JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
            //var a = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString, settings);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString, settings);
        }

        
    }
}
