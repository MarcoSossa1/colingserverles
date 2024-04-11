using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Afiliados
{
    public class AfiliadoService : IAfiliadoService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7065";

        public AfiliadoService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> BorrarAfiliado(int id, string token)
        {
            var endPoint = $"api/eliminarafiliado/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarAfiliado(Afiliado afiliado, string token)
        {
            var endPoint = $"api/modificarafiliado/{afiliado.Id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(afiliado), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarAfiliado(Afiliado afiliado, string token)
        {
            var endPoint = "api/insertarafiliado";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(afiliado), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Afiliado>> ListaAfiliados(string token)
        {
            var endPoint = "api/listarafiliados";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<Afiliado> result = new List<Afiliado>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Afiliado>>(responseBody);
            }

            return result;
        }

        public async Task<Afiliado> ObtenerAfiliadoPorId(int id, string token)
        {
            var endPoint = $"api/obtenerafiliadobyid/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Afiliado>(responseBody);
            }

            return null;
        }
    }
}
