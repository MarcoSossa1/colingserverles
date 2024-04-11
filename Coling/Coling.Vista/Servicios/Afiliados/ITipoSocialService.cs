using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios
{
    public interface ITipoSocialService
    {
        Task<List<TipoSocial>> ListaTiposSociales(string token);
        Task<bool> InsertarTipoSocial(TipoSocial tipoSocial, string token);
        Task<TipoSocial> ObtenerTipoSocialPorId(int id, string token);
        Task<bool> EditarTipoSocial(TipoSocial tipoSocial, string token);
        Task<bool> BorrarTipoSocial(int id, string token);
    }
}
