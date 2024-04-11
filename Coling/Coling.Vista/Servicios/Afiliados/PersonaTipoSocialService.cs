using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Coling.Vista.Servicios
{
    public class PersonaTipoSocialService : IPersonaTipoSocialService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7065";

        public PersonaTipoSocialService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> BorrarPersonaTipoSocial(int id, string token)
        {
            var endPoint = $"api/api/eliminarpersonatiposocial/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarPersonaTipoSocial(PersonaTipoSocial personaTipoSocial, string token)
        {
            var endPoint = $"api/modificarpersonatiposocial/{personaTipoSocial.Id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(personaTipoSocial), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarPersonaTipoSocial(PersonaTipoSocial personaTipoSocial, string token)
        {
            var endPoint = "api/insertarpersonatiposocial";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(personaTipoSocial), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<PersonaTipoSocial>> ListaPersonaTipoSociales(string token)
        {
            var endPoint = "api/listarpersonatipossocial";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<PersonaTipoSocial> result = new List<PersonaTipoSocial>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<PersonaTipoSocial>>(responseBody);
            }

            return result;
        }

        public async Task<PersonaTipoSocial> ObtenerPersonaTipoSocialPorId(int id, string token)
        {
            var endPoint = $"api/obtenerpersonatiposocialbyid/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PersonaTipoSocial>(responseBody);
            }

            return null;
        }
    }
}
