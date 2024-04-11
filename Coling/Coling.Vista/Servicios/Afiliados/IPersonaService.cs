using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios.Afiliados
{
    public interface IPersonaService
    {
        Task<List<Persona>> ListaPersonas(string token);
        Task<bool> InsertarPersona(Persona persona, string token);
        Task<Persona> ObtenerPersonaPorId(int id, string token);
        Task<bool> EditarPersona(Persona persona, string token);
        Task<bool> BorrarPersona(int id, string token);
    }
}
