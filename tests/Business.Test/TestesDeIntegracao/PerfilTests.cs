using Business.Test.TestesDeIntegracao.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web;
using Xunit;

namespace Business.Test.TestesDeIntegracao
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class PerfilTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public PerfilTests(IntegrationTestsFixture<Startup> integrationTestsFixture)
        {
            _testsFixture = integrationTestsFixture;
        }

        [Fact(DisplayName = "Realizar cadastro Perfil com sucesso")]
        [Trait("Categoria", "Integração Web - Perfil")]
        public async Task Usuario_RealizarCadastro_DeveExecutarComSucesso()
        {
            // Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/Administracao/CreatePerfil");
            initialResponse.EnsureSuccessStatusCode();

            var antiForgeryToken = _testsFixture.ObterAntiForgeryToken(await initialResponse.Content.ReadAsStringAsync());

            _testsFixture.GerarUserSenha();

            var formData = new Dictionary<string, string>
            {
                { _testsFixture.AntiForgeryFieldName, antiForgeryToken },
                {"Descricao", "Perfil Teste 1" },
                {"Funcionalidade", "Membros" },
                {"Permissoes", "Editar;Excluir;Atualizar" }
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Administracao/CreatePerfil")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            // Assert
            var responseString = await postResponse.Content.ReadAsStringAsync();

            postResponse.EnsureSuccessStatusCode();
            Assert.Contains("Adicionar Perfil", responseString);
        }
    }
}
