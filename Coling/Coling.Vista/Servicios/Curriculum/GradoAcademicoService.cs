
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
    public class GradoAcademicoService : IGradoAcademicoService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7023";

        public GradoAcademicoService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<GradoAcademico>> ListaGradosAcademicos(string token)
        {
            var endPoint = "api/ListarGradosAcademicos";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<GradoAcademico>>();
        }

        public async Task<bool> InsertarGradoAcademico(GradoAcademico gradoAcademico, string token)
        {
            var endPoint = "api/InsertarGradoAcademico";
            string jsonBody = JsonConvert.SerializeObject(gradoAcademico);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarGradoAcademico(GradoAcademico gradoAcademico, string token)
        {
            var endPoint = $"api/EditarGradoAcademico/{gradoAcademico.RowKey}";
            string jsonBody = JsonConvert.SerializeObject(gradoAcademico);

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endPoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el grado académico: {ex.Message}");
                return false;
            }
        }

        public async Task<GradoAcademico> ObtenerGradoAcademicoPorRowKey(string rowKey, string token)
        {
            var endPoint = $"api/ListarGradoAcademicoById/{rowKey}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GradoAcademico>();
                }
                else
                {
                    Console.WriteLine($"Error al obtener el grado académico. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el grado académico: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> BorrarGradoAcademico(string partitionKey, string rowKey, string token)
        {
            try
            {
                string endPoint = $"{BaseUrl}/api/BorrarGradoAcademico/{partitionKey}/{rowKey}";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = await _httpClient.DeleteAsync(endPoint);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al borrar el grado académico. Código de estado: {respuesta.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el grado académico: {ex.Message}");
                return false;
            }
        }
    }
}
