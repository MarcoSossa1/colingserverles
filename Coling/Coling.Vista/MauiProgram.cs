using Coling.Shared;
using Coling.Vista.Servicios;
using Coling.Vista.Servicios.Afiliados;
using Coling.Vista.Servicios.Curriculum;
using Coling.Vista.Servicios.BolsaTrabajo;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.Logging;

namespace Coling.Vista
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddSweetAlert2();
            builder.Services.AddHttpClient();
            builder.Services.AddMauiBlazorWebView();
            /*<--API AFILIADOS-->*/
            builder.Services.AddScoped<IPersonaService, PersonaService>();
            builder.Services.AddScoped<IAfiliadoService, AfiliadoService>();
            builder.Services.AddScoped<IAfiliadoIdiomaService, AfiliadoIdiomaService>();
            builder.Services.AddScoped<IDireccionService, DireccionService>();
            builder.Services.AddScoped<IGradoAcademicoService, GradoAcademicoService>();
            builder.Services.AddScoped<IIdiomaService, IdiomaService>();
            builder.Services.AddScoped<IProfesionService, ProfesionService>();
            builder.Services.AddScoped<ITelefonoService, TelefonoService>();
            builder.Services.AddScoped<ITipoSocialService, TipoSocialService>();
            /*<--API CURRICULUM-->*/
            builder.Services.AddScoped<IEstudioService, EstudioService>();
            builder.Services.AddScoped<IExperienciaLaboralService, ExperienciaLaboralService>();
            builder.Services.AddScoped<IGradoAcademicoService, GradoAcademicoService>();
            builder.Services.AddScoped<IInstitucionService, InstitucionService>();
            builder.Services.AddScoped<IProfesionService, ProfesionService>();
            builder.Services.AddScoped<ITipoEstudioService, TipoEstudioService>();
            /*<--API CURRICULUM-->*/
            builder.Services.AddScoped<ISolicitudService, SolicitudService>();
            builder.Services.AddScoped<IOfertaLaboralService, OfertaLaboralService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
