using AutoMapper;
using Business.Core.Intefaces;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class AdministracaoController : BaseController
    {
        private readonly IPermissaoService permissaoService;
        private readonly IMapper mapper;

        public AdministracaoController(INotificador notificador,
                                       IMapper _mapper,
                                       IPermissaoService _permissaoService) : base(notificador)
        {
            permissaoService = _permissaoService;
            mapper = _mapper;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region permissoes 
        
        #region perfil
        public async Task<IActionResult> Permissoes()
        {
            var lista = mapper.Map<IEnumerable<PermissaoViewModel>>(await permissaoService.ListarPermissao());
            return View("Permissoes/Perfil/Permissoes", lista);
        }

        public async Task<IActionResult> EditPermissao(string id)
        {
            var permissao = mapper.Map<PermissaoViewModel>(await permissaoService.BuscarPorId(id));
            if (permissao == null) return NotFound();

            return View("Permissoes/Perfil/Edit", permissao);
        }

        [HttpPost]
        public async Task<IActionResult> EditPermissao(PermissaoViewModel viewModel)
        {
            ModelState.Remove("Funcionalidade");
            ModelState.Remove("Perfil");

            if (!ModelState.IsValid) return View("Permissoes/Perfil/Edit",viewModel);

            var permissao = mapper.Map<Permissao>(viewModel);
            await permissaoService.EditarPermissao(permissao);

            if (!OperacaoValida()) return View("Pemissoes/Perfil/Edit",viewModel);

            return RedirectToAction("Permissoes");
        }

        public ActionResult CreatePermissao()
        {
            return View("Permissoes/Perfil/CreatePermissao", new PermissaoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissao(PermissaoViewModel model)
        {
            try
            {
                await permissaoService.SalvarPermissao(mapper.Map<Permissao>(model));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion

        #region usuario
        public async Task<IActionResult> PermissoesUsuario()
        {
            var lista = mapper.Map<IEnumerable<PermissaoViewModel>>(await permissaoService.ListarPermissao());
            return View("Permissoes/Usuario/Permissoes", lista);
        }

        public async Task<IActionResult> EditPermissaoUsuario(string id)
        {
            var permissao = mapper.Map<PermissaoViewModel>(await permissaoService.BuscarPorId(id));
            if (permissao == null) return NotFound();

            return View("Permissoes/Usuario/Edit", permissao);
        }

        [HttpPost]
        public async Task<IActionResult> EditPermissaoUsuario(PermissaoViewModel viewModel)
        {
            ModelState.Remove("Funcionalidade");
            ModelState.Remove("Perfil");

            if (!ModelState.IsValid) return View("Permissoes/Usuario/Edit", viewModel);

            var permissao = mapper.Map<Permissao>(viewModel);
            await permissaoService.EditarPermissao(permissao);

            if (!OperacaoValida()) return View("Pemissoes/Usuario/Edit", viewModel);

            return RedirectToAction("Permissoes");
        }

        public ActionResult CreatePermissaoUsuario()
        {
            return View("Permissoes/Usuario/CreatePermissao", new PermissaoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissaoUsuario(PermissaoViewModel model)
        {
            try
            {
                await permissaoService.SalvarPermissao(mapper.Map<Permissao>(model));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion

        #endregion permissoes
    }
}
