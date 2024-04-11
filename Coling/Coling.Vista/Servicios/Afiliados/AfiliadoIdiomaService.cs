using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Coling.Vista.Servicios.Afiliados
{
    public class AfiliadoIdiomaService : IAfiliadoIdiomaService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7065";

        public AfiliadoIdiomaService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> BorrarAfiliadoIdioma(int id, string token)
        {
            var endPoint = $"api/api/eliminarafiliadoidioma/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarAfiliadoIdioma(AfiliadoIdioma afiliadoIdioma, string token)
        {
            var endPoint = $"api/modificarafiliadoidioma/{afiliadoIdioma.Id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(afiliadoIdioma), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarAfiliadoIdioma(AfiliadoIdioma afiliadoIdioma, string token)
        {
            var endPoint = "api/insertarafiliadoidioma";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(afiliadoIdioma), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<AfiliadoIdioma>> ListaAfiliadoIdiomas(string token)
        {
            var endPoint = "api/listarafiliadoidiomas";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<AfiliadoIdioma> result = new List<AfiliadoIdioma>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<AfiliadoIdioma>>(responseBody);
            }

            return result;
        }

        public async Task<AfiliadoIdioma> ObtenerAfiliadoIdiomaPorId(int id, string token)
        {
            var endPoint = $"api/obtenerafiliadoidiomabyid/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AfiliadoIdioma>(responseBody);
            }

            return null;
        }
    }
}
