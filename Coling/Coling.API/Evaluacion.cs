using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Coling.API.Afiliados
{
    public class Evaluacion
    {
        private readonly ILogger<Evaluacion> _logger;
        private readonly Contexto _contexto;

        public Evaluacion(ILogger<Evaluacion> logger, Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        [Function("Ejer1")]
        
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }

    }
}
