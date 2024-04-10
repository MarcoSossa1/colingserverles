
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
    public class TipoEstudioService : ITipoEstudioService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7023";

        public TipoEstudioService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<TipoEstudio>> ListaTiposEstudio(string token)
        {
            var endPoint = "api/ListarTipoEstudios";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TipoEstudio>>();
        }

        public async Task<bool> InsertarTipoEstudio(TipoEstudio tipoEstudio, string token)
        {
            var endPoint = "api/InsertarTipoEstudio";
            string jsonBody = JsonConvert.SerializeObject(tipoEstudio);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarTipoEstudio(TipoEstudio tipoEstudio, string token)
        {
            var endPoint = $"api/EditarTipoEstudio/{tipoEstudio.RowKey}";
            string jsonBody = JsonConvert.SerializeObject(tipoEstudio);

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endPoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el tipo de estudio: {ex.Message}");
                return false;
            }
        }

        public async Task<TipoEstudio> ObtenerTipoEstudioPorRowKey(string rowKey, string token)
        {
            var endPoint = $"api/ListarTipoEstudioById/{rowKey}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TipoEstudio>();
                }
                else
                {
                    Console.WriteLine($"Error al obtener el tipo de estudio. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el tipo de estudio: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> BorrarTipoEstudio(string partitionKey, string rowKey, string token)
        {
            try
            {
                string endPoint = $"{BaseUrl}/api/BorrarTipoEstudio/{partitionKey}/{rowKey}";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = await _httpClient.DeleteAsync(endPoint);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al borrar el tipo de estudio. Código de estado: {respuesta.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el tipo de estudio: {ex.Message}");
                return false;
            }
        }
    }
}
