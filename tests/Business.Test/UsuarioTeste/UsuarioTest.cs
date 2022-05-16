using Business.Interfaces;
using Business.Services;
using Business.Test.Permissoes;
using Business.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Business.Test.UsuarioTeste
{
    public class UsuarioTest
    {
        private readonly UserPerfilTestFixture userPerfilTestFixture;
        private readonly UsuarioService usuarioService;
        private UserValidation userValidation;

        public UsuarioTest()
        {
            userPerfilTestFixture = new UserPerfilTestFixture();
            usuarioService = userPerfilTestFixture.ObterUsuarioService();
            userValidation = new UserValidation();
        }

        [Fact(DisplayName = "Novo Usuario válido")]
        [Trait("Categoria", "Usuario Fixture Testes")]
        public async void Adicionar_NovoUsuario_DeveEstarValido()
        {
            // Arrange
            var user = userPerfilTestFixture.GerarUsuarioValido();

            // Act
            await usuarioService.AdicionarUsuario(user);

            //Assert
            userPerfilTestFixture.MockerUser.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarUsuario(user), Times.Once);
            Assert.True(userValidation.Validate(user).IsValid);
        }
    }
}
