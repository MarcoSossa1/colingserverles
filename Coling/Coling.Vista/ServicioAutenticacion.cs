using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista
{
    public class ServicioAutenticacion
    {
        private readonly HttpClient httpClient;

        public ServicioAutenticacion()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> ObtenerToken(string usuario, string contraseña)
        {
            var parametros = new Dictionary<string, string>
        {
            { "usuario", usuario },
            { "contraseña", contraseña }
        };

            var respuesta = await httpClient.PostAsync("http://localhost:7087/api/Login", new FormUrlEncodedContent(parametros));

            if (respuesta.IsSuccessStatusCode)
            {
                var token = await respuesta.Content.ReadAsStringAsync();
                return token;
            }
            else
            {
                throw new Exception("Error al iniciar sesión");
            }
        }
    }
}
