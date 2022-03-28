using Business.Interfaces;
using Business.Models;
using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Business.Test.ProjetoTeste
{
    [Collection(nameof(ProjetoCollection))]
    public class ProjetoTeste
    {
        private readonly ProjetoTesteFixture _projetoTestsFixture;
        private readonly IProjetoService _projetoService;
        private readonly ITestOutputHelper _output; 

        public ProjetoTeste(ProjetoTesteFixture projetoTestsFixture, ITestOutputHelper outputHelper)
        {
            _projetoService = projetoTestsFixture.ObterProjetoService();
            _projetoTestsFixture = projetoTestsFixture;
            _output = outputHelper;
        }

        [Fact(DisplayName = "Novo Projeto Inválido")]
        [Trait("Categoria", "Projeto Fixture Testes")]
        public void Adicionar_NovoProjeto_DeveEstarInvalido()
        {
            // Arrange
            var teste = new Mock<Projeto>();          
            var projeto = _projetoTestsFixture.GerarProjetoInValido();

            // Act
            var result = _projetoTestsFixture.EhValido(projeto);

            // Assert 
            //Assert.False(result);

            //FluentAssertions
            result.Should().BeFalse();
            _output.WriteLine("Teste verificado com FluentAssertions.");
        }

        [Fact(DisplayName = "Adicionar Novo Projeto válido")]
        [Trait("Categoria", "Projeto Fixture Testes")]
        public void Adicionar_NovoProjeto_DeveEstarValido()
        {
            // Arrange
            var projeto = _projetoTestsFixture.GerarProjetoValido();

            // Act
            _projetoService.Adicionar(projeto);

            // Assert 
            //Assert.True(_projetoTestsFixture.EhValido(projeto));

            //Assert FluentAssertions
            _projetoTestsFixture.EhValido(projeto).Should().BeTrue();

            //Verifica se o método adicionar foi chamado pelo menos uma vez
            _projetoTestsFixture.Mocker.GetMock<IProjetoRepository>().Verify(x => x.Adicionar(projeto), Times.Once);          
        }

        [Fact(DisplayName = "Atualiza Novo Projeto válido")]
        [Trait("Categoria", "Projeto Fixture Testes")]
        public void Atualizar_NovoProjeto_DeveEstarValido()
        {
            // Arrange
            var projeto = _projetoTestsFixture.GerarProjetoValido();

            // Act
            _projetoService.Atualizar(projeto);

            // Assert 
            //Assert.True(_projetoTestsFixture.EhValido(projeto));

            //Assert FluentAssertions
            _projetoTestsFixture.EhValido(projeto).Should().BeTrue();

            //Verifica se o método adicionar foi chamado pelo menos uma vez
            _projetoTestsFixture.Mocker.GetMock<IProjetoRepository>().Verify(x => x.Atualizar(projeto), Times.Once);
        }

        [Fact(DisplayName = "Atualiza Novo Projeto inválido")]
        [Trait("Categoria", "Projeto Fixture Testes")]
        public void Atualizar_NovoProjeto_DeveEstarInvalido()
        {
            // Arrange
            var projeto = _projetoTestsFixture.GerarProjetoInValido();

            // Act
            _projetoService.Atualizar(projeto);

            // Assert 
            //Assert.True(_projetoTestsFixture.EhValido(projeto));

            //Assert FluentAssertions
            _projetoTestsFixture.EhValido(projeto).Should().BeFalse();
            _projetoTestsFixture.Mocker.GetMock<IProjetoRepository>().Verify(x => x.Atualizar(projeto), Times.Never);
        }
    }
}
