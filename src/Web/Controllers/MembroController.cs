using System;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Models;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Web.Models;
using Business.Core.Intefaces;

namespace Web.Controllers
{
    public class MembroController : BaseController
    {
        private readonly IMembroService service;
        private readonly IMapper mapper;

        public MembroController(IMembroService _service, 
                                IMapper _mapper, 
                                INotificador notificador):base(notificador)
        {
            service = _service;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {            
            var lista = mapper.Map<List<MembroViewModel>>(await service.ListarTodos());
            return View(lista);
        }
    
        public async Task<IActionResult> Details(string id)
        {
            var membroViewModel = mapper.Map<MembroViewModel>(await service.BuscarPorId(id));

            if (membroViewModel == null) return NotFound();            

            return View(membroViewModel);
        }

        public IActionResult CreateMembro()
        {
            return View(new MembroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembro(MembroViewModel model)
        {         
            await service.AdicionarMembro(mapper.Map<Membro>(model));

            if (!OperacaoValida()) return View(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var membroViewModel = mapper.Map<MembroViewModel>(await service.BuscarPorId(id));

            if (membroViewModel == null)
            {
                return NotFound();
            }

            return View(membroViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(MembroViewModel membroViewModel)
        {
            if (!ModelState.IsValid) return View(membroViewModel); 

            var membro = mapper.Map<Membro>(membroViewModel);
            await service.AtualizarMembro(membro);         

            if (!OperacaoValida()) return View(membroViewModel);

            return RedirectToAction("Index");
        }
   
        public async Task<IActionResult> Delete(string id)
        {
            var membroViewModel = mapper.Map<MembroViewModel>(await service.BuscarPorId(id));
            if (membroViewModel == null) return NotFound();

            return View(membroViewModel);
        }    
    
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var membro = await service.BuscarPorId(id);

            if (membro == null) return NotFound();

            await service.ExcluirMembro(membro);

            if (!OperacaoValida()) return View(membro);

            return RedirectToAction("Index");
        }
    }
}