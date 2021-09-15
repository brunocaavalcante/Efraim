using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class ProjetoViewModel : EntityViewModel
    {
       
        public string Titulo { get; set; }
        
        public string Descricao { get; set; }
        
        public MembroViewModel Responsavel { get; set; }
        
        public List<MembroViewModel> Participantes { get; set; }
        
        public DateTime DataInicio { get; set; }
        
        public DateTime DataFim { get; set; }
    }
}
