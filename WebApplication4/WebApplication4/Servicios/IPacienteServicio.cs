using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Servicios
{
    public interface IPacienteServicio
    {
        Task<List<Paciente>> ObtenerPacientes();
        Task<int> Count();
        Task<int> NuevoPaciente(Paciente paciente);
        Task<int> EliminarPaciente(Paciente paciente);
        Task<int> ActualizarPaciente(Paciente paciente);
    }
}
