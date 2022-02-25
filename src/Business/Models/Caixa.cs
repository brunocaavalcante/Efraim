using Business.Core.Models;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class Caixa : Entity
    {
        public decimal ValorTotal { get; set; }
        public decimal ValorObtido { get; set; }
        public decimal ValorPendente { get; set; }
        public List<Deposito> Deposito { get; set; }
    }

    public class Deposito : Entity
    {
        public decimal Valor { get; set; }
        public DateTime DataDeposito { get; set; }
        public Usuario Contribuinte { get; set; }
    }
}
