using Azure.Data.Tables;
using Coling.API.Curriculum.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.RegularExpressions;

namespace Coling.API.Curriculum
{
    public class Examen
    {
        private readonly string? cadenaConexion;
        private readonly string tablaNombre1;
        private readonly string tablaNombre2;
        private readonly IConfiguration configuration;
        private readonly ILogger<Examen> _logger;

        public Examen(ILogger<Examen> logger, IConfiguration conf)
        {
            _logger = logger;
            configuration = conf;
            cadenaConexion = configuration.GetSection("cadenaconexion").Value;
            tablaNombre1 = "Estudio";
            tablaNombre2 = "Institucion";
        }
        // Lista todos los Estudios donde la PartitionKey es Estudios y el Estado sea Activo
        [Function("E1")]
        [OpenApiOperation("E1", "E1")]
        public async Task<HttpResponseData> E1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "E1")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre1);
                var filtro = $"PartitionKey eq 'Estudios' and Estado eq 'Activo'";
                List<Estudio> listaEstudios = new List<Estudio>();
                await foreach (Estudio estudio in tablaCliente.QueryAsync<Estudio>(filter: filtro))
                {
                    listaEstudios.Add(estudio);
                }
                await response.WriteAsJsonAsync(listaEstudios);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estudios: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                await response.WriteAsJsonAsync($"Error al obtener estudios: {ex.Message}");
                return response;
            }
        }

        // Lista todos los Estudios donde la PartitionKey es Estudios y el año está en el rango de 2000 a 2010
        [Function("E2")]
        [OpenApiOperation("E2", "E2")]
        public async Task<HttpResponseData> E2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "E2")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre1);
                var filtro = $"PartitionKey eq 'Estudios' and (Año ge 2000 and Año le 2010)";
                List<Estudio> listaEstudios = new List<Estudio>();

                await foreach (Estudio estudio in tablaCliente.QueryAsync<Estudio>(filter: filtro))
                {
                    listaEstudios.Add(estudio);
                }

                await response.WriteAsJsonAsync(listaEstudios);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estudios: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                await response.WriteAsJsonAsync($"Error al obtener estudios: {ex.Message}");
                return response;
            }
        }

        // Lista todos los Estudios donde la PartitionKey es Estudios y el atributo TipoEstudio contiene la letra "a" y "o"
        [Function("E3")]
        [OpenApiOperation("E3", "E3")]
        public async Task<HttpResponseData> E3(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "E3")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre1);
                var filtro = $"PartitionKey eq 'Estudios' and (TipoEstudio contains 'a' and TipoEstudio contains 'o')";
                List<Estudio> listaEstudios = new List<Estudio>();

                await foreach (Estudio estudio in tablaCliente.QueryAsync<Estudio>(filter: filtro))
                {
                    listaEstudios.Add(estudio);
                }

                await response.WriteAsJsonAsync(listaEstudios);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estudios: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                await response.WriteAsJsonAsync($"Error al obtener estudios: {ex.Message}");
                return response;
            }
        }

        // Lista todos los Estudios donde la PartitionKey es Estudios y el atributo TipoEstudio contiene solo letras consonantes
        [Function("E4")]
        [OpenApiOperation("E4", "E4")]
        public async Task<HttpResponseData> E4(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "E4")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre1);
                // Expresión regular para verificar si el atributo TipoEstudio contiene solo consonantes
                var regex = new Regex(@"^[bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]+$");
                List<Estudio> listaEstudios = new List<Estudio>();

                await foreach (Estudio estudio in tablaCliente.QueryAsync<Estudio>())
                {
                    // Verificar si el atributo TipoEstudio contiene solo consonantes
                    if (regex.IsMatch(estudio.TipoEstudio))
                    {
                        listaEstudios.Add(estudio);
                    }
                }

                await response.WriteAsJsonAsync(listaEstudios);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estudios: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                await response.WriteAsJsonAsync($"Error al obtener estudios: {ex.Message}");
                return response;
            }
        }

    }
}
