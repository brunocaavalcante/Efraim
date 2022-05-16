using System.Collections.Generic;

namespace Web.Models
{
    public class CaixaViewModel
    {
        public decimal ValorTotal { get; set; }
        public decimal ValorObtido { get; set; }
        public decimal ValorPendente { get; set; }
        public IEnumerable<DepositoViewModel> Depositos { get; set; }
    }
}
