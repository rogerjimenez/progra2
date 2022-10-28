using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication4.Modelos;
using WebApplication4.Servicios;

namespace WebApplication4.Controllers
{
    [Produces("application/json")]
    [Route("api/Especialidad")]
    public class EspecialidadController : Controller
    {
        private readonly IEspecialidadServicio especialidadServicio;

        public EspecialidadController(IEspecialidadServicio especialidadServicio)
        {
            this.especialidadServicio = especialidadServicio;
        }

        // GET: PacienteController
        [HttpGet("")]
        public async Task<IActionResult> Test()
        {
            try
            {
                var especialidad = await this.especialidadServicio.ObtenerEspecialidades();
                return Ok(especialidad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("")]
        public async Task<IActionResult> Actualziar([FromBody] Especialidad especialidad)
        {
            try
            {
                var actualizado = await this.especialidadServicio.ActualizarEspecialidad(especialidad);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> Agregar([FromBody] Especialidad especialidad)
        {
            try
            {
                var agregado = await this.especialidadServicio.NuevoEspecialidad(especialidad);
                return Ok(agregado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{IdEspecialidad:int}")]
        public async Task<IActionResult> Eliminar(int idEspecialidad)
        {
            try
            {
                var eliminado = await this.especialidadServicio.EliminarEspecialidad(new Especialidad
                {
                    IdEspecialidad = idEspecialidad
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
