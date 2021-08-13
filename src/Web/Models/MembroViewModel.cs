using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class MembroViewModel
    {
        public string Id {get;set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

         [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }
        
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

    }
}