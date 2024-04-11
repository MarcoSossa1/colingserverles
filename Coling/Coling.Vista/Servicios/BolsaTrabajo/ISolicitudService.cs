using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios.BolsaTrabajo
{
    public interface ISolicitudService
    {
        Task<List<Solicitud>> ListaSolicitudes(string token);
        Task<bool> InsertarSolicitud(Solicitud solicitud, string token);
        Task<Solicitud> ObtenerSolicitudPorId(string id, string token);
        Task<bool> EditarSolicitud(Solicitud solicitud, string token);
        Task<bool> BorrarSolicitud(string id, string token);
    }
}
