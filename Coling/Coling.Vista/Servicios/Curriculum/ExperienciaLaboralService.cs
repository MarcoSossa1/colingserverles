
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
    public class ExperienciaLaboralService : IExperienciaLaboralService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7023";

        public ExperienciaLaboralService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<ExperienciaLaboral>> ListaExperienciasLaborales(string token)
        {
            var endPoint = "api/ListarExperienciasLaborales";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ExperienciaLaboral>>();
        }

        public async Task<bool> InsertarExperienciaLaboral(ExperienciaLaboral experienciaLaboral, string token)
        {
            var endPoint = "api/InsertarExperienciaLaboral";
            string jsonBody = JsonConvert.SerializeObject(experienciaLaboral);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarExperienciaLaboral(ExperienciaLaboral experienciaLaboral, string token)
        {
            var endPoint = $"api/EditarExperienciaLaboral/{experienciaLaboral.RowKey}";
            string jsonBody = JsonConvert.SerializeObject(experienciaLaboral);

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endPoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar la experiencia laboral: {ex.Message}");
                return false;
            }
        }

        public async Task<ExperienciaLaboral> ObtenerExperienciaLaboralPorRowKey(string rowKey, string token)
        {
            var endPoint = $"api/ListarExperienciaLaboralById/{rowKey}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ExperienciaLaboral>();
                }
                else
                {
                    Console.WriteLine($"Error al obtener la experiencia laboral. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la experiencia laboral: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> BorrarExperienciaLaboral(string partitionKey, string rowKey, string token)
        {
            try
            {
                string endPoint = $"{BaseUrl}/api/BorrarExperienciaLaboral/{partitionKey}/{rowKey}";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = await _httpClient.DeleteAsync(endPoint);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al borrar la experiencia laboral. Código de estado: {respuesta.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar la experiencia laboral: {ex.Message}");
                return false;
            }
        }
    }
}
