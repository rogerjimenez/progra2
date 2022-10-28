using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication4.Modelos;
using WebApplication4.Servicios;

namespace WebApplication4.Controllers
{
    [Produces("application/json")]
    [Route("api/Medico")]
    public class MedicoController : Controller
    {
        private readonly IMedicoServicio medicoServicio;

        public MedicoController(IMedicoServicio medicoServicio)
        {
            this.medicoServicio = medicoServicio;
        }

        // GET: PacienteController
        [HttpGet("")]
        public async Task<IActionResult> Test()
        {
            try
            {
                var medico = await this.medicoServicio.ObtenerMedicos();
                return Ok(medico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("")]
        public async Task<IActionResult> Actualziar([FromBody] Medico medico)
        {
            try
            {
                var actualizado = await this.medicoServicio.ActualizarMedico(medico);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> Agregar([FromBody] Medico medico)
        {
            try
            {
                var agregado = await this.medicoServicio.NuevoMedico(medico);
                return Ok(agregado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{IdMedico:int}")]
        public async Task<IActionResult> Eliminar(int idMedico)
        {
            try
            {
                var eliminado = await this.medicoServicio.EliminarMedico(new Medico
                {
                    IdMedico = idMedico
                });
                return Ok(eliminado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
