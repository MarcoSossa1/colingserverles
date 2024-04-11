using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Afiliados
{
    public class DireccionService : IDireccionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:7065";

        public DireccionService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> BorrarDireccion(int id, string token)
        {
            var endPoint = $"api/eliminardireccion/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarDireccion(Direccion direccion, string token)
        {
            var endPoint = $"api/modificardireccion/{direccion.Id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(direccion), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarDireccion(Direccion direccion, string token)
        {
            var endPoint = "api/insertardireccion";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(direccion), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endPoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Direccion>> ListaDirecciones(string token)
        {
            var endPoint = "api/listardirecciones";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<Direccion> result = new List<Direccion>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Direccion>>(responseBody);
            }

            return result;
        }


        public async Task<Direccion> ObtenerDireccionPorId(int id, string token)
        {
            var endPoint = $"api/obtenerdireccionbyid/{id}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Direccion>(responseBody);
            }

            return null;
        }
        public async Task<List<Direccion>> ListarDireccionesPorPersona(int idPersona, string token)
        {
            var endPoint = $"api/listardireccionesporpersona/{idPersona}";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(endPoint);
            List<Direccion> result = new List<Direccion>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Direccion>>(responseBody);
            }

            return result;
        }

    }
}
