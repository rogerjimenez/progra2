using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication4.Modelos;
using WebApplication4.Servicios;

namespace WebApplication4.Controllers
{
    [Produces("application/json")]
    [Route("api/Paciente")]
    public class PacienteController : Controller
    {
        private readonly IPacienteServicio pacienteServicio;

        public PacienteController(IPacienteServicio pacienteServicio)
        {
            this.pacienteServicio = pacienteServicio;
        }

        // GET: PacienteController
        [HttpGet("")]
        public async Task<IActionResult> Test()
        {
            try {
                var pacientes = await this.pacienteServicio.ObtenerPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualziar([FromBody] Paciente paciente)
        {
            try
            {
                var actualizado = await this.pacienteServicio.ActualizarPaciente(paciente);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> Agregar([FromBody] Paciente paciente)
        {
            try
            {
                var agregado = await this.pacienteServicio.NuevoPaciente(paciente);
                return Ok(agregado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{IdPaciente:int}")]
        public async Task<IActionResult> Eliminar(int idPaciente)
        {
            try
            {
                var eliminado = await this.pacienteServicio.EliminarPaciente(new Paciente { 
                    IdPaciente = idPaciente
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
