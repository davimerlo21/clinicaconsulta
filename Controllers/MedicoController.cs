using clinicaconsulta.Models;
using clinicaconsulta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clinicaconsulta.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoService _medicoService;
        private readonly IEspecialidadeService _especialidadeService;

        public MedicoController(IMedicoService medicoService, IEspecialidadeService especialidadeService)
        {
            _medicoService = medicoService;
            _especialidadeService = especialidadeService;
        }

        public async Task<IActionResult> Index()
        {
            var medicos = await _medicoService.ListarTodosAsync();
            return View(medicos);
        }

        public async Task<IActionResult> Criar()
        {
            ViewBag.Especialidades = new SelectList(await _especialidadeService.ListarTodasAsync(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                await _medicoService.CadastrarAsync(medico);
                TempData["Sucesso"] = "Médico cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Especialidades = new SelectList(await _especialidadeService.ListarTodasAsync(), "Id", "Nome", medico.EspecialidadeId);
            return View(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            await _medicoService.ExcluirAsync(id);
            TempData["Sucesso"] = "Médico excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}