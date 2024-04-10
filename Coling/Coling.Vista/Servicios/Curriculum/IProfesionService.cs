using Coling.Vista.Modelos.API.Curriculum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public interface IProfesionService
    {
        Task<List<Profesion>> ListaProfesiones(string token);
        Task<bool> InsertarProfesion(Profesion profesion, string token);
        Task<Profesion> ObtenerProfesionPorRowKey(string rowKey, string token);
        Task<bool> EditarProfesion(Profesion profesion, string token);
        Task<bool> BorrarProfesion(string partitionKey, string rowKey, string token);
    }
}
