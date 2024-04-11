using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.BolsaTrabajo
{
    public class OfertaLaboralService : IOfertaLaboralService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7019";

        public OfertaLaboralService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> BorrarOfertaLaboral(string id, string token)
        {
            var endPoint = $"api/EliminarOfertaLaboral/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarOfertaLaboral(OfertaLaboral ofertaLaboral, string token)
        {
            var endPoint = $"api/ModificarOfertaLaboral/{ofertaLaboral.Id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(ofertaLaboral), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarOfertaLaboral(OfertaLaboral ofertaLaboral, string token)
        {
            var endPoint = "api/InsertarOfertaLaboral";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(ofertaLaboral), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<OfertaLaboral>> ListaOfertasLaborales(string token)
        {
            var endPoint = "api/ListarOfertasLaborales";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<OfertaLaboral> result = new List<OfertaLaboral>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<OfertaLaboral>>(responseBody);
            }

            return result;
        }

        public async Task<OfertaLaboral> ObtenerOfertaLaboralPorId(string id, string token)
        {
            var endPoint = $"api/ObtenerOfertaLaboralById/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OfertaLaboral>(responseBody);
            }

            return null;
        }
    }
}
