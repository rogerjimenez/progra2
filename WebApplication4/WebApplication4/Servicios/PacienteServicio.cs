using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;
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

        public async Task<int> ActualizarPaciente(Paciente paciente)
        {
            var actualizao = await this.pacienteRepositorio.ActualizarPaciente(paciente);
            return actualizao;
        }

        public async Task<int> ConteoAsync()
        {
            return await this.pacienteRepositorio.Count();
        }

        public async Task<int> Count()
        {
            return await this.pacienteRepositorio.Count();
        }

        public async Task<int> EliminarPaciente(Paciente paciente)
        {
            var eliminado = await this.pacienteRepositorio.EliminarPaciente(paciente);
            return eliminado;
        }

        public async Task<int> NuevoPaciente(Paciente paciente)
        {
            var insertado = await this.pacienteRepositorio.NuevoPaciente(paciente);
            return insertado;
        }

        public async Task<List<Paciente>> ObtenerPacientes()
        {
            var listado = await this.pacienteRepositorio.ObtenerPacientes();
            return listado;
        }
    }
}
