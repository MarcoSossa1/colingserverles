using Coling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.BolsaTrabajo
{
    public interface IOfertaLaboralService
    {
        Task<List<OfertaLaboral>> ListaOfertasLaborales(string token);
        Task<bool> InsertarOfertaLaboral(OfertaLaboral ofertaLaboral, string token);
        Task<OfertaLaboral> ObtenerOfertaLaboralPorId(string id, string token);
        Task<bool> EditarOfertaLaboral(OfertaLaboral ofertaLaboral, string token);
        Task<bool> BorrarOfertaLaboral(string id, string token);
    }
}
