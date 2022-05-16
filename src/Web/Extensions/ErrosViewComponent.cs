
using Business.Core.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Extensions
{
    public class ErrosViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;
        public ErrosViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            foreach (var notificacao in notificacoes)
            {
                ViewData.ModelState.AddModelError("", notificacao.Mensagem);
            }

            return View();
        }
    }
}