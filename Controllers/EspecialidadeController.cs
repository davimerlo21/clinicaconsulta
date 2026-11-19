using clinicaconsulta.Models;
using clinicaconsulta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinicaconsulta.Controllers
{
    public class EspecialidadeController : Controller
    {
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        public async Task<IActionResult> Index()
        {
            var especialidades = await _especialidadeService.ListarTodasAsync();
            return View(especialidades);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                await _especialidadeService.CadastrarAsync(especialidade);
                TempData["Sucesso"] = "Especialidade cadastrada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(especialidade);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            await _especialidadeService.ExcluirAsync(id);
            TempData["Sucesso"] = "Especialidade excluída com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}