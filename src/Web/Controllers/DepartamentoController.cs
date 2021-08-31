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

        public async Task<IActionResult> AdicionarMembro(DepartamentoViewModel departamentoViewModel)
        {
            var departamento = await service.BuscarPorId(departamentoViewModel.Id);
            var membro = await membroService.BuscarPorColuna("CPF", departamentoViewModel.Membro.CPF);
            
            await service.AdicionarMembro(departamento, membro);
            if(!OperacaoValida()) return View("Edit", departamentoViewModel);

            return RedirectToAction("Edit", new { id = departamento.Id } );
        }

        public async Task<IActionResult> Create()
        {  
            return View(new DepartamentoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartamentoViewModel viewModel)
        {
            await service.Adicionar(mapper.Map<Departamento>(viewModel));
            
            if(!OperacaoValida()) return View(viewModel);

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
            await service.Atualizar(departamento);         

            if (!OperacaoValida()) return View(departamentoViewModel);

            return RedirectToAction("Index");
        }

    }
}