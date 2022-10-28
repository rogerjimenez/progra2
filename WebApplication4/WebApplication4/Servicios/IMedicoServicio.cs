using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Servicios
{
    public interface IMedicoServicio
    {

        Task<List<Medico>> ObtenerMedicos();
        Task<int> NuevoMedico(Medico medico);
        Task<int> EliminarMedico(Medico medico);
        Task<int> ActualizarMedico(Medico medico);
    }
}
