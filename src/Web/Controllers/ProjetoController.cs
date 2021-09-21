using AutoMapper;
using Business.Core.Intefaces;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class ProjetoController : BaseController
    {
        private readonly IProjetoService service;
        private readonly IMapper mapper;

        public ProjetoController(INotificador notificador,
                                 IMapper _mapper,
                                 IProjetoService projetoService) : base(notificador)
        {
            service = projetoService;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lista = mapper.Map<List<ProjetoViewModel>>(await service.Listar());
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            return View(new ProjetoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjetoViewModel viewModel)
        {
            await service.Adicionar(mapper.Map<Projeto>(viewModel));

            if (!OperacaoValida()) return View(viewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var projetoViewModel = mapper.Map<ProjetoViewModel>(await service.BuscarPorId(id));

            if (projetoViewModel == null)
            {
                return NotFound();
            }

            return View(projetoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjetoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var projeto = mapper.Map<Projeto>(viewModel);
            await service.Atualizar(projeto);

            if (!OperacaoValida()) return View(viewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = mapper.Map<ProjetoViewModel>(await service.BuscarPorId(id));
            if (viewModel == null) return NotFound();

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var viewModel = mapper.Map<ProjetoViewModel>(await service.BuscarPorId(id));
            if (viewModel == null) return NotFound();

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var entity = await service.BuscarPorId(id);

            if (entity == null) return NotFound();

            await service.Excluir(entity);

            if (!OperacaoValida()) return View(entity);

            return RedirectToAction("Index");
        }

    }
}
