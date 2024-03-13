using Coling.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.API.Afiliados.Contratos
{
    public interface IIdiomaLogic
    {
        Task<bool> InsertarIdioma(Idioma idioma);
        Task<bool> ModificarIdioma(Idioma idioma, int id);
        Task<bool> EliminarIdioma(int id);
        Task<List<Idioma>> ListarIdiomas();
        Task<Idioma> ObtenerIdiomaById(int id);
    }
}
