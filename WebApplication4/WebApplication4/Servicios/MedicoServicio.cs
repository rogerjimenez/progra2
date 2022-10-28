using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;
using WebApplication4.Repositorios;

namespace WebApplication4.Servicios
{
    public class MedicoServicio : IMedicoServicio
    {
        private IMedicoRepositorio medicoRepositorio;

        public MedicoServicio(IMedicoRepositorio medicoRepositorio)
        {
            this.medicoRepositorio = medicoRepositorio;
        }
        public async Task<int> ActualizarMedico(Medico medico)
        {
            var actualizao = await this.medicoRepositorio.ActualizarMedico(medico);
            return actualizao;
        }

        public async Task<int> EliminarMedico(Medico medico)
        {
            var eliminado = await this.medicoRepositorio.EliminarMedico(medico);
            return eliminado;
        }

        public async Task<int> NuevoMedico(Medico medico)
        {
            var insertado = await this.medicoRepositorio.NuevoMedico(medico);
            return insertado;
        }

        public async Task<List<Medico>> ObtenerMedicos()
        {
            var listado = await this.medicoRepositorio.ObtenerMedicos();
            return listado;
        }
    }
}
