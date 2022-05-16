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
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService service;
        private readonly IMapper mapper;

        public UsuarioController(IUsuarioService _service,
                                IMapper _mapper,
                                INotificador notificador) : base(notificador)
        {
            service = _service;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lista = mapper.Map<List<UsuarioViewModel>>(await service.ListarTodos());
            lista.ForEach(x => x.Controller = "usuario");
            return View(lista);
        }

        public async Task<IActionResult> Details(string id)
        {
            var usuarioViewModel = mapper.Map<UsuarioViewModel>(await service.BuscarPorId(id));

            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        public IActionResult Create()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioViewModel model)
        {
            await service.AdicionarUsuario(mapper.Map<Usuario>(model));

            if (!OperacaoValida()) return View(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var usuarioViewModel = mapper.Map<UsuarioViewModel>(await service.BuscarPorId(id));

            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            var usuario = mapper.Map<Usuario>(usuarioViewModel);
            await service.AtualizarUsuario(usuario);

            if (!OperacaoValida()) return View(usuarioViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var usuarioViewModel = mapper.Map<UsuarioViewModel>(await service.BuscarPorId(id));
            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await service.BuscarPorId(id);

            if (usuario == null) return NotFound();

            await service.ExcluirUsuario(usuario);

            if (!OperacaoValida()) return View(usuario);

            return RedirectToAction("Index");
        }
    }
}