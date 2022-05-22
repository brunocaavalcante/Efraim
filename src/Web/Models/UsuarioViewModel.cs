using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UsuarioViewModel : EntityViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O {0} fornecido é inválido!", MinimumLength = 14)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ConfirmeSenha { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

        public string IdProjeto { get; set; }

        public string IdDepartamento { get; set; }

        public IEnumerable<DepartamentoViewModel> Departamentos { get; set; }

        public IEnumerable<ProjetoViewModel> Projetos { get; set; }

        public PerfilViewModel Perfil { get; set; }
        public List<PerfilViewModel> ListaPerfil { get; set; }
    }
}