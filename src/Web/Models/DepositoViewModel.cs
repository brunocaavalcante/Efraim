using System;

namespace Web.Models
{
    public class DepositoViewModel
    {
        public decimal Valor { get; set; }
        public DateTime DataDeposito { get; set; }
        public UsuarioViewModel Contribuinte { get; set; }
    }
}
