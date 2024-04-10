using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Coling.API.Afiliados
{
    public class Examen
    {
        private readonly Contexto _contexto;
        private readonly ILogger<Examen> _logger;

        public Examen(ILogger<Examen> logger, Contexto contexto)
        {
            _contexto = contexto;
            _logger = logger;
        }

        [Function("Ejercicio1")]
        [OpenApiOperation("E1","E1")]
        public async Task<HttpResponseData> ListarPMarco(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "E1")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var personas = await _contexto.Personas.Where(x => x.Nombre == "Marco").ToListAsync();
            var respuesta = req.CreateResponse(HttpStatusCode.OK);
            await respuesta.WriteAsJsonAsync(personas);
            return respuesta;
        }
        [Function("Ejercicio2")]
        [OpenApiOperation("E2", "E2")]
        public async Task<HttpResponseData> E2(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "E2")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var afiliados = await _contexto.Afiliados.Where(x => x.Estado == "Activo").
                                                      Select(x=> new dt1
                                                      { 
                                                        id = x.Id,
                                                        nombre = x.NroTituloProvisional
                                                      }).ToListAsync();
            var respuesta = req.CreateResponse(HttpStatusCode.OK);
            await respuesta.WriteAsJsonAsync(afiliados);
            return respuesta;
        }
        [Function("Ejercicio3")]
        [OpenApiOperation("E3", "E3")]
        public async Task<HttpResponseData> ListarPersonasConLetrasAE(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "E3")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Filtrar las personas cuyo nombre contenga 'a' y 'e'
            var personas = await _contexto.Personas.Where(x => x.Nombre.Contains("a") && x.Nombre.Contains("e")).ToListAsync();

            // Crear la respuesta HTTP con el código de estado OK
            var respuesta = req.CreateResponse(HttpStatusCode.OK);

            // Escribir la lista de personas como JSON en el cuerpo de la respuesta
            await respuesta.WriteAsJsonAsync(personas);

            // Devolver la respuesta HTTP
            return respuesta;
        }
        [Function("Ejercicio4")]
        [OpenApiOperation("E4", "E4")]
        public async Task<HttpResponseData> ListarPersonasNacidasEn1990(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "E4")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Obtener el año 1990 como DateTime
            var fechaNacimiento1990 = new DateTime(1990, 1, 1);

            // Filtrar las personas cuya fecha de nacimiento sea en 1990
            var personas = await _contexto.Personas.Where(x => x.FechaNacimiento.Year == 1990).ToListAsync();

            // Crear la respuesta HTTP con el código de estado OK
            var respuesta = req.CreateResponse(HttpStatusCode.OK);

            // Escribir la lista de personas como JSON en el cuerpo de la respuesta
            await respuesta.WriteAsJsonAsync(personas);

            // Devolver la respuesta HTTP
            return respuesta;
        }

        public class dt1 
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }
    }
}
