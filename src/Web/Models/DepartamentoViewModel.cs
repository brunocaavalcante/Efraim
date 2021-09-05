using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web.Models
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel()
        {
            Membro = new MembroViewModel();
            Membros = new List<MembroViewModel>();
            Lider = new List<MembroViewModel>();
        }
        public string Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome{ get; set;}

        public string Descricao {get;set;}
        
        [ValidateNever]
        public MembroViewModel Membro{ get; set; }

        public List<MembroViewModel> Membros{ get; set; }

        public List<MembroViewModel> Lider{ get; set; }

        public DateTime DataCadastro { get; set; }
    }
}