using Business.Models;
using Business.Services;
using Business.Validations;
using FluentValidation.Results;
using Moq.AutoMock;
using System;
using Xunit;

namespace Business.Test.TestesDeUnidade.ProjetoTeste
{
    [CollectionDefinition(nameof(ProjetoCollection))]
    public class ProjetoCollection : ICollectionFixture<ProjetoTesteFixture>
    { }

    public class ProjetoTesteFixture : IDisposable
    {
        public ProjetoService _projetoService;
        public AutoMocker Mocker;

        public ProjetoService ObterProjetoService()
        {
            Mocker = new AutoMocker();
            _projetoService = Mocker.CreateInstance<ProjetoService>();
            return _projetoService;
        }

        public FluentValidation.Results.ValidationResult ValidationResult { get; private set; }

        public Projeto GerarProjetoValido()
        {
            var projeto = new Projeto
            {
                Id = "01",
                DataFim = DateTime.Now.AddDays(+30),
                DataInicio = DateTime.Now,
                Descricao = "Teste Valido",
                Titulo = "Testando",
                Responsavel =  new Usuario { Nome = "Bruno", CPF = "111.777.666-99", Email = "teste@gmail.com" }
            };

            return projeto;
        }

        public Projeto GerarProjetoInValido()
        {
            var projeto = new Projeto
            {
                Id = "",
                DataFim = DateTime.Now.AddDays(-30),
                DataInicio = DateTime.Now,
                Descricao = "Teste Invalido",
                Titulo = "",
                Responsavel = null
            };

            return projeto;
        }

        public bool EhValido(Projeto projeto)
        {
            ValidationResult = new ProjetoValidation().Validate(projeto);
            return ValidationResult.IsValid;
        }

        public void Dispose()
        {
        }
    }
}
