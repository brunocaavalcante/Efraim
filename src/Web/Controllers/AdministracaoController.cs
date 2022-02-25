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
        public ActionResult Permissoes()
        {
            List<PermissaoViewModel> lista = new List<PermissaoViewModel>();
            return View(lista);
        }

        public ActionResult CreatePermissao()
        {
            return View(new PermissaoViewModel());
        }

        [HttpPost]
        public ActionResult CreatePermissao(PermissaoViewModel model)
        {
            try
            {
                permissaoService.SalvarPermissao(mapper.Map<Permissao>(model));
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        #endregion permissoes
    }
}
