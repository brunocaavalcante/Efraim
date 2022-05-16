using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel()
        {
            Membro = new UsuarioViewModel();
            Membros = new List<UsuarioViewModel>();
            Lideres = new List<UsuarioViewModel>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [ValidateNever]
        public UsuarioViewModel Membro { get; set; }

        public List<UsuarioViewModel> Membros { get; set; }

        public List<UsuarioViewModel> Lideres { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}