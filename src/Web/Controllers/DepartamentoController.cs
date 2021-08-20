using Business.Core.Intefaces;
using Business.Interfaces;

namespace Web.Controllers
{
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoService service;
        public DepartamentoController(IDepartamentoService _service, 
                                      INotificador notificador) : base(notificador)
        {
            service = _service;
        }
    }
}