using Business.Models;
using Moq;
using Xunit;

namespace Business.Test.ProjetoTeste
{
    [Collection(nameof(ProjetoCollection))]
    public class TesteProjetoInvalido
    {
        private readonly ProjetoTesteFixture _projetoTestsFixture;

        public TesteProjetoInvalido(ProjetoTesteFixture projetoTestsFixture)
        {
            _projetoTestsFixture = projetoTestsFixture;
        }

        [Fact(DisplayName = "Novo Projeto Inválido")]
        [Trait("Categoria", "Projeto Fixture Testes")]
        public void Cliente_NovoProjeto_DeveEstarInvalido()
        {
            // Arrange
            var teste = new Mock<Projeto>();          
            var projeto = _projetoTestsFixture.GerarProjetoInValido();

            // Act
            var result = _projetoTestsFixture.EhValido(projeto);

            // Assert 
            Assert.False(result);
           // Assert.NotEqual(0, projeto.ValidationResult.Errors.Count);
        }
    }
}
