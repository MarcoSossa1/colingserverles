using System.Collections.Generic;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coling.Vista.Servicios.Afiliados
{
    public interface IAfiliadoService
    {
        Task<List<Afiliado>> ListaAfiliados(string token);
        Task<bool> InsertarAfiliado(Afiliado afiliado, string token);
        Task<Afiliado> ObtenerAfiliadoPorId(int id, string token);
        Task<bool> EditarAfiliado(Afiliado afiliado, string token);
        Task<bool> BorrarAfiliado(int id, string token);
    }
}
