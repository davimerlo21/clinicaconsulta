using clinicaconsulta.Services.Interfaces;
using clinicaconsulta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clinicaconsulta.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaService _consultaService;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;

        public ConsultaController(IConsultaService consultaService, IMedicoService medicoService, IPacienteService pacienteService)
        {
            _consultaService = consultaService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var consultas = await _consultaService.ListarTodasAsync();
            return View(consultas);
        }

        // GET: Consulta/Criar
        public async Task<IActionResult> Criar()
        {
            ViewBag.Medicos = new SelectList(await _medicoService.ListarTodosAsync(), "Id", "Nome");
            ViewBag.Pacientes = new SelectList(await _pacienteService.ListarTodosAsync(), "Id", "Nome");
            return View();
        }

        // POST: Consulta/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _consultaService.AgendarConsultaAsync(consulta);

                if (resultado.Sucesso)
                {
                    TempData["Sucesso"] = resultado.Mensagem;
                    return RedirectToAction(nameof(Index));
                }

                // Se houver conflito de horário, mostra a mensagem de erro
                ModelState.AddModelError(string.Empty, resultado.Mensagem);
            }

            ViewBag.Medicos = new SelectList(await _medicoService.ListarTodosAsync(), "Id", "Nome", consulta.MedicoId);
            ViewBag.Pacientes = new SelectList(await _pacienteService.ListarTodosAsync(), "Id", "Nome", consulta.PacienteId);
            return View(consulta);
        }

        // POST: Consulta/Excluir/5
        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            await _consultaService.ExcluirAsync(id);
            TempData["Sucesso"] = "Consulta cancelada com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}