using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Repositorios
{
    public interface IMedicoRepositorio
    {
        Task<List<Medico>> ObtenerMedicos();
        Task<int> NuevoMedico(Medico medico);
        Task<int> EliminarMedico(Medico medico);
        Task<int> ActualizarMedico(Medico medico);
    }
}
