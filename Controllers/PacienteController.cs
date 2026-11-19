using clinicaconsulta.Models;
using clinicaconsulta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinicaconsulta.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.ListarTodosAsync();
            return View(pacientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                await _pacienteService.CadastrarAsync(paciente);
                TempData["Sucesso"] = "Paciente cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            await _pacienteService.ExcluirAsync(id);
            TempData["Sucesso"] = "Paciente excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}