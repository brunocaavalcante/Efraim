using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel()
        {
            Membro = new MembroViewModel();
            Membros = new List<MembroViewModel>();
        }
        public string Id { get; set; }
        
        public string Nome{ get; set;}

        public string Descricao {get;set;}

        public MembroViewModel Membro{ get; set; }

        public List<MembroViewModel> Membros{ get; set; }

        public List<MembroViewModel> Lider{ get; set; }

        public DateTime DataCadastro { get; set; }
    }
}