using Coling.Vista.Modelos.API.Curriculum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public interface IExperienciaLaboralService
    {
        Task<List<ExperienciaLaboral>> ListaExperienciasLaborales(string token);
        Task<bool> InsertarExperienciaLaboral(ExperienciaLaboral experienciaLaboral, string token);
        Task<ExperienciaLaboral> ObtenerExperienciaLaboralPorRowKey(string rowKey, string token);
        Task<bool> EditarExperienciaLaboral(ExperienciaLaboral experienciaLaboral, string token);
        Task<bool> BorrarExperienciaLaboral(string partitionKey, string rowKey, string token);
    }
}
