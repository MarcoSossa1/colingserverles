using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios.Afiliados
{
    public interface IDireccionService
    {
        Task<List<Direccion>> ListaDirecciones(string token);
        Task<bool> InsertarDireccion(Direccion direccion, string token);
        Task<Direccion> ObtenerDireccionPorId(int id, string token);
        Task<bool> EditarDireccion(Direccion direccion, string token);
        Task<bool> BorrarDireccion(int id, string token);
    }
}
