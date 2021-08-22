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
        private readonly IMapper mapper;
        public DepartamentoController(IDepartamentoService _service,
                                      IMapper _mapper, 
                                      INotificador notificador) : base(notificador)
        {
            service = _service;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {            
            //var lista = mapper.Map<List<DepartamentoViewModel>>(await service.Listar());
            return View(new List<DepartamentoViewModel>());
        }

        public IActionResult Create()
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

    }
}