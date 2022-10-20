using System.Threading.Tasks;
using WebApplication4.Repositorios;

namespace WebApplication4.Servicios
{
    public class PacienteServicio: IPacienteServicio
    {
        private IPacienteRepositorio pacienteRepositorio;

        public PacienteServicio(IPacienteRepositorio pacienteRepositorio)
        {
            this.pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<int> ConteoAsync()
        {
            return await this.pacienteRepositorio.Count();
        }
    }
}
