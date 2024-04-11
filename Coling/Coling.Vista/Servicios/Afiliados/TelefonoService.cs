using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Coling.Vista.Servicios
{
    public class TelefonoService : ITelefonoService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7065";

        public TelefonoService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> BorrarTelefono(int id, string token)
        {
            var endPoint = $"api/eliminartelefono/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarTelefono(Telefono telefono, string token)
        {
            var endPoint = $"api/modificartelefono/{telefono.Id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(telefono), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarTelefono(Telefono telefono, string token)
        {
            var endPoint = "api/insertartelefono";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(telefono), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Telefono>> ListaTelefonos(string token)
        {
            var endPoint = "api/listartelefonos";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<Telefono> result = new List<Telefono>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Telefono>>(responseBody);
            }

            return result;
        }

        public async Task<Telefono> ObtenerTelefonoPorId(int id, string token)
        {
            var endPoint = $"api/obtenertelefonobyid/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Telefono>(responseBody);
            }

            return null;
        }
        public async Task<List<Telefono>> ListaTelefonosPorPersona(int idPersona, string token)
        {
            var endPoint = $"api/listartelefonosporpersona/{idPersona}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<Telefono> result = new List<Telefono>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Telefono>>(responseBody);
            }

            return result;
        }
    }
}
