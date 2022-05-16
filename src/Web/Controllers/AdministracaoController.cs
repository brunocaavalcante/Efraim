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
        private readonly IPerfilService perfilService;
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;

        public AdministracaoController(INotificador notificador,
                                       IMapper _mapper,
                                       IUsuarioService _usuarioService,
                                       IPerfilService _perfilService,
                                       IPermissaoService _permissaoService) : base(notificador)
        {
            permissaoService = _permissaoService;
            usuarioService = _usuarioService;
            perfilService = _perfilService;
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
        public async Task<IActionResult> PerfilIndex()
        {
            var lista = mapper.Map<IEnumerable<PerfilViewModel>>(await perfilService.Listar());
            return View("Permissoes/Perfil/Index", lista);
        }

        public async Task<IActionResult> EditPermissao(string id)
        {
            var permissao = mapper.Map<PerfilViewModel>(await permissaoService.BuscarPorId(id));
            if (permissao == null) return NotFound();

            return View("Permissoes/Perfil/Edit", permissao);
        }

        [HttpPost]
        public async Task<IActionResult> EditPermissao(PerfilViewModel viewModel)
        {
            ModelState.Remove("Funcionalidade");
            ModelState.Remove("Perfil");

            if (!ModelState.IsValid) return View("Permissoes/Perfil/Edit", viewModel);

            var permissao = mapper.Map<Perfil>(viewModel);
            await permissaoService.EditarPermissao(permissao);

            if (!OperacaoValida()) return View("Pemissoes/Perfil/Edit", viewModel);

            return RedirectToAction("Permissoes");
        }

        public ActionResult CreatePerfil()
        {
            return View("Permissoes/Perfil/Create", new PerfilViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerfil(PerfilViewModel model)
        {
            try
            {
                await perfilService.Salvar(mapper.Map<Perfil>(model));
                return RedirectToAction(nameof(PerfilIndex));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion

        #region usuario
        public async Task<IActionResult> PerfilUsuario()
        {
            var viewModel = new UsuarioPerfilViewModel();
            viewModel.Usuarios = await RetornaUsuarios();
            viewModel.ListaPerfil = mapper.Map<List<PerfilViewModel>>(await perfilService.Listar());
            return View("Permissoes/Usuario/Perfil", viewModel);
        }

        public async Task<IActionResult> EditPermissaoUsuario(string id)
        {
            var permissao = mapper.Map<PerfilViewModel>(await permissaoService.BuscarPorId(id));
            if (permissao == null) return NotFound();

            return View("Permissoes/Usuario/Edit", permissao);
        }

        [HttpPost]
        public async Task<IActionResult> EditPermissaoUsuario(PerfilViewModel viewModel)
        {
            ModelState.Remove("Funcionalidade");
            ModelState.Remove("Perfil");

            if (!ModelState.IsValid) return View("Permissoes/Usuario/Edit", viewModel);

            var permissao = mapper.Map<Perfil>(viewModel);
            await permissaoService.EditarPermissao(permissao);

            if (!OperacaoValida()) return View("Pemissoes/Usuario/Edit", viewModel);

            return RedirectToAction("Permissoes");
        }

        public ActionResult CreatePerfilUsuario()
        {
            return View("Permissoes/Usuario/CreatePermissao", new PerfilViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPerfilUsuario(string idUsuario, string idPerfil)
        {
            try
            {
                var usuario = await usuarioService.BuscarPorId(idUsuario);
                var perfil = await perfilService.BuscarPorId(idPerfil);
                var sucesso = await perfilService.SalvarPerfilUsuario(perfil, usuario);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoverPerfilUsuario(string idUsuario, string idPerfil)
        {
            try
            {                
                var usuario = await usuarioService.BuscarPorId(idUsuario);
                usuario.ListaPerfil = await perfilService.RetornaPerfilUsuario(usuario);

                var perfil = await perfilService.BuscarPorId(idPerfil);
                perfil = usuario.ListaPerfil.Where(p => p.Descricao == perfil.Descricao).FirstOrDefault();

                var sucesso = await perfilService.RemoverPerfilUsuario(perfil, usuario);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private async Task<List<UsuarioViewModel>> RetornaUsuarios()
        {
            var lista = mapper.Map<List<UsuarioViewModel>>(await usuarioService.ListarTodos());

            foreach(var item in lista)
            {
                item.ListaPerfil = mapper.Map<List<PerfilViewModel>>(await perfilService.RetornaPerfilUsuario(mapper.Map<Usuario>(item)));
            }

            return lista;
        }
        #endregion

        #endregion permissoes
    }
}
