using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ProjetoViewModel : EntityViewModel
    {
        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }
        
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        
        public MembroViewModel Responsavel { get; set; }
        
        public List<MembroViewModel> Participantes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Inícial")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Final")]
        public DateTime DataFim { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
