using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Core.Intefaces;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoService service;
        private readonly IMembroService membroService;
        private readonly IMapper mapper;
        public DepartamentoController(IDepartamentoService _service,
                                      IMembroService _membroService,
                                      IMapper _mapper,
                                      INotificador notificador) : base(notificador)
        {
            service = _service;
            membroService = _membroService;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lista = mapper.Map<List<DepartamentoViewModel>>(await service.Listar());
            return View(lista);
        }

        public IActionResult Create()
        {
            return View(new DepartamentoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartamentoViewModel viewModel)
        {
            await service.Adicionar(mapper.Map<Departamento>(viewModel));

            if (!OperacaoValida()) return View(viewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var departamentoViewModel = mapper.Map<DepartamentoViewModel>(await service.BuscarPorId(id));

            if (departamentoViewModel == null) return NotFound();

            return View(departamentoViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var departamentoViewModel = mapper.Map<DepartamentoViewModel>(await service.BuscarPorId(id));
            departamentoViewModel.Membros.ForEach(x => { x.IdDepartamento = departamentoViewModel.Id; x.Controller = "Departamento"; });

            if (departamentoViewModel == null)
            {
                return NotFound();
            }

            return View(departamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartamentoViewModel departamentoViewModel)
        {
            if (!ModelState.IsValid) return View(departamentoViewModel);

            var departamento = mapper.Map<Departamento>(departamentoViewModel);
            departamento.Membros = (await service.BuscarPorId(departamentoViewModel.Id)).Membros;
            departamento.Lideres = (await service.BuscarPorId(departamentoViewModel.Id)).Lideres;

            await service.Atualizar(departamento);

            if (!OperacaoValida()) return View(departamentoViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var departamentoViewModel = mapper.Map<DepartamentoViewModel>(await service.BuscarPorId(id));
            if (departamentoViewModel == null) return NotFound();

            return View(departamentoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var departamento = await service.BuscarPorId(id);

            if (departamento == null) return NotFound();

            await service.Excluir(departamento);

            if (!OperacaoValida()) return View(departamento);

            return RedirectToAction("Index");
        }

        #region Membro
        [HttpPost]
        public async Task<IActionResult> AdicionarMembro(DepartamentoViewModel departamentoViewModel)
        {
            ModelState.Remove("Nome");
            var departamento = await service.BuscarPorId(departamentoViewModel.Id);
            var membro = await membroService.BuscarPorColuna("CPF", departamentoViewModel.Membro.CPF.Replace("-", "").Replace(".", ""));

            await service.AdicionarMembro(departamento, membro);
            if (!OperacaoValida()) return View("Edit", mapper.Map<DepartamentoViewModel>(departamento));

            return RedirectToAction("Details", new { id = departamento.Id });
        }

        public async Task<IActionResult> RemoverMembro(string idDepartamento, string idMembro)
        {
            var departamento = await service.BuscarPorId(idDepartamento);
            var membro = await membroService.BuscarPorId(idMembro);

            await service.RemoverMembro(departamento, membro);
            return RedirectToAction("Details", new { id = departamento.Id });
        }
        #endregion

        #region Lider
        [HttpPost]
        public async Task<IActionResult> AdicionarLider(DepartamentoViewModel departamentoViewModel)
        {
            ModelState.Remove("Nome");

            var departamento = await service.BuscarPorId(departamentoViewModel.Id);
            var membro = await membroService.BuscarPorColuna("CPF", departamentoViewModel.Membro.CPF.Replace("-", "").Replace(".", ""));

            await service.AdicionarLider(departamento, membro);
            if (!OperacaoValida()) return View("Details", mapper.Map<DepartamentoViewModel>(departamento));

            return RedirectToAction("Details", new { id = departamento.Id });
        }

        public async Task<IActionResult> RemoverLider(string idDepartamento, string idMembro)
        {
            var departamento = await service.BuscarPorId(idDepartamento);
            var membro = await membroService.BuscarPorId(idMembro);

            await service.RemoverLider(departamento, membro);
            return RedirectToAction("Details", new { id = departamento.Id });
        }
        #endregion
    }
}