using Business.Interfaces;
using Business.Models;
using Business.Services;
using Business.Validations;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Business.Test.Permissoes
{
    public class UserPerfilTest
    {
        private readonly UserPerfilTestFixture userPerfilTestFixture;
        private readonly PerfilService service;
        private readonly UsuarioService usuarioService;
        private UserValidation userValidation;
        private PermissaoValidation permissaoValidation;

        public UserPerfilTest()
        {
            userPerfilTestFixture = new UserPerfilTestFixture();
            service = userPerfilTestFixture.ObterPerfilService();
            usuarioService = userPerfilTestFixture.ObterUsuarioService();
            userValidation = new UserValidation();
            permissaoValidation = new PermissaoValidation();
        }

        [Fact(DisplayName = "Novo Perfil ao Usuario válido")]
        [Trait("Categoria", "Permissao Fixture Testes")]
        public async void Adicionar_NovoPerifilaUsuario_DeveEstarValido()
        {
            // Arrange
            var teste = new Mock<Usuario>();
            var user = userPerfilTestFixture.GerarUsuarioValido();
            var perfil = userPerfilTestFixture.GerarPerfilValido();

            // Act
            var result = await service.SalvarPerfilUsuario(perfil, user);

            //Assert
            userPerfilTestFixture.Mocker.GetMock<IPerfilRepository>().Verify(r => r.SalvarPerfilUsuario(perfil, user), Times.Once);
            Assert.True(permissaoValidation.Validate(perfil).IsValid);
            Assert.True(userValidation.Validate(user).IsValid);
        }

        [Fact(DisplayName = "Novo Perfil ao Usuario invalido")]
        [Trait("Categoria", "Permissao Fixture Testes")]
        public async void Adicionar_NovoPerifilaUsuario_DeveEstar_Invalido()
        {
            // Arrange
            var teste = new Mock<Usuario>();
            var user = userPerfilTestFixture.GerarUsuarioInvalido();
            var permissao = userPerfilTestFixture.GerarPerfilInvalido();

            // Act
            var result = await service.SalvarPerfilUsuario(permissao, user);

            //Assert
            userPerfilTestFixture.Mocker.GetMock<IPerfilRepository>().Verify(r => r.SalvarPerfilUsuario(permissao, user), Times.Never);
            Assert.False(result);
            Assert.False(permissaoValidation.Validate(permissao).IsValid);
            Assert.False(userValidation.Validate(user).IsValid);
        }

        [Fact(DisplayName = "Remover Perfil de Usuario")]
        [Trait("Categoria", "Permissao Fixture Testes")]
        public async void Remover_PerifildeUsuario()
        {
            // Arrange
            var user = userPerfilTestFixture.GerarUsuarioInvalido();
            var permissao = userPerfilTestFixture.GerarPerfilInvalido();

            // Act
            var result = await service.RemoverPerfilUsuario(permissao, user);

            //Assert
            userPerfilTestFixture.Mocker.GetMock<IPerfilRepository>().Verify(r => r.RemoverPerfilUsuario(permissao, user), Times.Once);
            Assert.False(permissaoValidation.Validate(permissao).IsValid);
            Assert.False(userValidation.Validate(user).IsValid);
        }

        [Fact(DisplayName = "Retorna perfils por usuario")]
        [Trait("Categoria", "Permissao Fixture Testes")]
        public async void Retorna_lista_perfil_usuarios()
        {
            //Arrange
            var user = userPerfilTestFixture.GerarUsuarioValido();

            // Act
            var result = await service.RetornaPerfilUsuario(user);

            //Assert
            userPerfilTestFixture.Mocker.GetMock<IPerfilRepository>().Verify(r => r.RetornaPerfilUsuario(user), Times.Once);
        }


    }
}
