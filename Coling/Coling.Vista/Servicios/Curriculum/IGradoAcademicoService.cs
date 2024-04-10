using Coling.Vista.Modelos.API.Curriculum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public interface IGradoAcademicoService
    {
        Task<List<GradoAcademico>> ListaGradosAcademicos(string token);
        Task<bool> InsertarGradoAcademico(GradoAcademico gradoAcademico, string token);
        Task<GradoAcademico> ObtenerGradoAcademicoPorRowKey(string rowKey, string token);
        Task<bool> EditarGradoAcademico(GradoAcademico gradoAcademico, string token);
        Task<bool> BorrarGradoAcademico(string partitionKey, string rowKey, string token);
    }
}
