using Coling.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.API.Afiliados.Contratos
{
    public interface IAfiliadoLogic
    {
        Task<bool> InsertarAfiliado(Afiliado afiliado);
        Task<bool> ModificarAfiliado(Afiliado afiliado, int id);
        Task<bool> EliminarAfiliado(int id);
        Task<List<Afiliado>> ListarAfiliados();
        Task<Afiliado> ObtenerAfiliadoById(int id);
    }
}
