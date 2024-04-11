using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios
{
    public interface ITelefonoService
    {
        Task<List<Telefono>> ListaTelefonos(string token);
        Task<bool> InsertarTelefono(Telefono telefono, string token);
        Task<Telefono> ObtenerTelefonoPorId(int id, string token);
        Task<bool> EditarTelefono(Telefono telefono, string token);
        Task<bool> BorrarTelefono(int id, string token);
    }
}
