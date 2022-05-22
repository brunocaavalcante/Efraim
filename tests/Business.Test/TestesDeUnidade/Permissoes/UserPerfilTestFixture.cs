using Business.Models;
using Business.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Test.TestesDeUnidade.Permissoes
{
    public class UserPerfilTestFixture : IDisposable
    {
        public PerfilService _perfilService;
        public UsuarioService _usuarioService;
        public AutoMocker Mocker;
        public AutoMocker MockerUser;

        public PerfilService ObterPerfilService()
        {
            Mocker = new AutoMocker();
            _perfilService = Mocker.CreateInstance<PerfilService>();

            return _perfilService;
        }

        public UsuarioService ObterUsuarioService()
        {
            MockerUser = new AutoMocker();
            _usuarioService = MockerUser.CreateInstance<UsuarioService>();           
            return _usuarioService;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Usuario GerarUsuarioValido()
        {
            var user = new Usuario
            {
                Id = "7AH0v4nd4FW0yxWCkUiT6saNYqT2",
                CPF = "44577361809",
                DataNascimento = new DateTime(1996, 7, 26),
                Email = "teste@gmail.com",
                Nome = "Bruno Cavalcante",
                ListaPerfil = new List<Perfil>(),
                Telefone = "11964490371"
            };
            user.ListaPerfil.Add(new Perfil { Descricao = "usuario" });
            return user;
        }
        public Usuario GerarUsuarioInvalido()
        {
            var user = new Usuario
            {
                CPF = "44577361",
                DataNascimento = new DateTime(1900, 7, 26),
                Email = "testegmail.com",
                Nome = "Bruno@ Cavalcante",
                ListaPerfil = new List<Perfil>(),
                Telefone = "11964490fdfd371"
            };
            user.ListaPerfil.Add(new Perfil { Descricao = "usuario" });
            return user;
        }

        public Perfil GerarPerfilValido()
        {
            return new Perfil { Descricao = "Administrador", Funcionalidade = "Projetos", Permissoes = "Editar;Salvar;Excluir" };
        }


        public Perfil GerarPerfilInvalido()
        {
            return new Perfil { Descricao = "", Funcionalidade = "", Permissoes = null };
        }
    }
}
