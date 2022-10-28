using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;
using WebApplication4.Repositorios;

namespace WebApplication4.Servicios
{
    public class EspecialidadServicio : IEspecialidadServicio
    {
        private IEspecialidadRepositorio especialidadRepositorio;

        public EspecialidadServicio(IEspecialidadRepositorio especialidadRepositorio)
        {
            this.especialidadRepositorio = especialidadRepositorio;
        }

        public async Task<int> ActualizarEspecialidad(Especialidad especialidad)
        {
            var actualizao = await this.especialidadRepositorio.ActualizarEspecialidad(especialidad);
            return actualizao;
        }

        public async Task<int> EliminarEspecialidad(Especialidad especialidad)
        {
            var eliminado = await this.especialidadRepositorio.EliminarEspecialidad(especialidad);
            return eliminado;
        }

        public async Task<int> NuevoEspecialidad(Especialidad especialidad)
        {
            var insertado = await this.especialidadRepositorio.NuevoEspecialidad(especialidad);
            return insertado;
        }

        public async Task<List<Especialidad>> ObtenerEspecialidades()
        {
            var listado = await this.especialidadRepositorio.ObtenerEspecialidades();
            return listado;
        }
    }
}
