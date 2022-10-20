using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
                var algo = await this.pacienteServicio.ConteoAsync();
                return Ok("Funciona "+ algo);
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
            
        }

        // GET: PacienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
