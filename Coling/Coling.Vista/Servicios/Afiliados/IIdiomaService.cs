using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios.Afiliados
{
    public interface IIdiomaService
    {
        Task<List<Idioma>> ListaIdiomas(string token);
        Task<bool> InsertarIdioma(Idioma idioma, string token);
        Task<Idioma> ObtenerIdiomaPorId(int id, string token);
        Task<bool> EditarIdioma(Idioma idioma, string token);
        Task<bool> BorrarIdioma(int id, string token);
    }
}
