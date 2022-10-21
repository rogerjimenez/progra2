using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Repositorios
{
    public interface IPacienteRepositorio
    {
        Task<List<Paciente>> ObtenerPacientes();
        Task<int> Count();
        Task<int> NuevoPaciente(Paciente paciente);
        Task<int> EliminarPaciente(Paciente paciente);
        Task<int> ActualizarPaciente(Paciente paciente);
    }
}
