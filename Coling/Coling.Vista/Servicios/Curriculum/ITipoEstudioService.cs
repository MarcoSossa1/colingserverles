using Coling.Vista.Modelos.API.Curriculum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public interface ITipoEstudioService
    {
        Task<List<TipoEstudio>> ListaTiposEstudio(string token);
        Task<bool> InsertarTipoEstudio(TipoEstudio tipoEstudio, string token);
        Task<TipoEstudio> ObtenerTipoEstudioPorRowKey(string rowKey, string token);
        Task<bool> EditarTipoEstudio(TipoEstudio tipoEstudio, string token);
        Task<bool> BorrarTipoEstudio(string partitionKey, string rowKey, string token);
    }
}
