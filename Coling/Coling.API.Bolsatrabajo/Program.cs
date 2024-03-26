using Coling.API.Bolsatrabajo.Contratos;
using Coling.API.Bolsatrabajo.Implementacion;
using Coling.Utilitarios.Middlewares;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<ISolicitudLogic, SolicitudLogic>();
        services.AddScoped<IOfertaLaboralLogic, OfertaLaboralLogic>();
        services.AddSingleton<JwtMiddleware>();

    }).ConfigureFunctionsWebApplication(x =>
    {
        x.UseMiddleware<JwtMiddleware>();
    })
    .Build();

host.Run();
