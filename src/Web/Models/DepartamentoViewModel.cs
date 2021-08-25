using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class DepartamentoViewModel
    {
        public string Id { get; set; }
        
        public string Nome{ get; set;}

        public string Descricao {get;set;}

        public List<MembroViewModel> Membros{ get; set; }

        public List<MembroViewModel> ListaMembros{ get; set; }

        public List<MembroViewModel> Lider{ get; set; }

        public DateTime DataCadastro { get; set; }
    }
}