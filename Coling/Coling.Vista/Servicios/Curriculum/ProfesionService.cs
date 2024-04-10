
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
    public class ProfesionService : IProfesionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7023";

        public ProfesionService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<Profesion>> ListaProfesiones(string token)
        {
            var endPoint = "api/ListarProfesiones";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Profesion>>();
        }

        public async Task<bool> InsertarProfesion(Profesion profesion, string token)
        {
            var endPoint = "api/InsertarProfesion";
            string jsonBody = JsonConvert.SerializeObject(profesion);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarProfesion(Profesion profesion, string token)
        {
            var endPoint = $"api/EditarProfesion/{profesion.RowKey}";
            string jsonBody = JsonConvert.SerializeObject(profesion);

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endPoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar la profesión: {ex.Message}");
                return false;
            }
        }

        public async Task<Profesion> ObtenerProfesionPorRowKey(string rowKey, string token)
        {
            var endPoint = $"api/ListarProfesionById/{rowKey}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Profesion>();
                }
                else
                {
                    Console.WriteLine($"Error al obtener la profesión. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la profesión: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> BorrarProfesion(string partitionKey, string rowKey, string token)
        {
            try
            {
                string endPoint = $"{BaseUrl}/api/BorrarProfesion/{partitionKey}/{rowKey}";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = await _httpClient.DeleteAsync(endPoint);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al borrar la profesión. Código de estado: {respuesta.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar la profesión: {ex.Message}");
                return false;
            }
        }
    }
}
