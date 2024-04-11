using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios.Afiliados
{
    public interface IAfiliadoIdiomaService
    {
        Task<List<AfiliadoIdioma>> ListaAfiliadoIdiomas(string token);
        Task<bool> InsertarAfiliadoIdioma(AfiliadoIdioma afiliadoIdioma, string token);
        Task<AfiliadoIdioma> ObtenerAfiliadoIdiomaPorId(int id, string token);
        Task<bool> EditarAfiliadoIdioma(AfiliadoIdioma afiliadoIdioma, string token);
        Task<bool> BorrarAfiliadoIdioma(int id, string token);
    }
}
