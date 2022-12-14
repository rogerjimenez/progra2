using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Servicios
{
    public interface IEspecialidadServicio
    {
        Task<List<Especialidad>> ObtenerEspecialidades();
        Task<int> NuevoEspecialidad(Especialidad especialidad);
        Task<int> EliminarEspecialidad(Especialidad especialidad);
        Task<int> ActualizarEspecialidad(Especialidad especialidad);
    }
}
