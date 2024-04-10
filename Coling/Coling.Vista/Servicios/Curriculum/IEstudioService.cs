using Coling.Vista.Modelos.API.Curriculum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public interface IEstudioService
    {
        Task<List<Estudio>> ListaEstudios(string token);
        Task<bool> InsertarEstudio(Estudio estudio, string token);
        Task<Estudio> ObtenerEstudioPorRowKey(string rowKey, string token);
        Task<bool> EditarEstudio(Estudio estudio, string token);
        Task<bool> BorrarEstudio(string partitionKey, string rowKey, string token);
    }
}
