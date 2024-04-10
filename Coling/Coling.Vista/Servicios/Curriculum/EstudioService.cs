
using Coling.Vista.Modelos.API.Curriculum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public class EstudioService : IEstudioService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7023";

        public EstudioService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<Estudio>> ListaEstudios(string token)
        {
            var endPoint = "api/ListarEstudios";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Estudio>>();
        }

        public async Task<bool> InsertarEstudio(Estudio estudio, string token)
        {
            var endPoint = "api/InsertarEstudio";
            string jsonBody = JsonConvert.SerializeObject(estudio);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarEstudio(Estudio estudio, string token)
        {
            var endPoint = $"api/EditarEstudio/{estudio.RowKey}";
            string jsonBody = JsonConvert.SerializeObject(estudio);

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endPoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el estudio: {ex.Message}");
                return false;
            }
        }

        public async Task<Estudio> ObtenerEstudioPorRowKey(string rowKey, string token)
        {
            var endPoint = $"api/ListarEstudioById/{rowKey}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Estudio>();
                }
                else
                {
                    Console.WriteLine($"Error al obtener el estudio. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el estudio: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> BorrarEstudio(string partitionKey, string rowKey, string token)
        {
            try
            {
                string endPoint = $"{BaseUrl}/api/BorrarEstudio/{partitionKey}/{rowKey}";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = await _httpClient.DeleteAsync(endPoint);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al borrar el estudio. Código de estado: {respuesta.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el estudio: {ex.Message}");
                return false;
            }
        }
    }
}
