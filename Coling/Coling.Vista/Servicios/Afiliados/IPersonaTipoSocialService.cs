using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios
{
    public interface IPersonaTipoSocialService
    {
        Task<List<PersonaTipoSocial>> ListaPersonaTipoSociales(string token);
        Task<bool> InsertarPersonaTipoSocial(PersonaTipoSocial personaTipoSocial, string token);
        Task<PersonaTipoSocial> ObtenerPersonaTipoSocialPorId(int id, string token);
        Task<bool> EditarPersonaTipoSocial(PersonaTipoSocial personaTipoSocial, string token);
        Task<bool> BorrarPersonaTipoSocial(int id, string token);
    }
}
