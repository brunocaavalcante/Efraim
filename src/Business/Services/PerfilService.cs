using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
using Business.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PerfilService : BaseService, IPerfilService
    {
        private readonly IPerfilRepository repository;
        public PerfilService(INotificador notificador, IPerfilRepository _repository) : base(notificador)
        {
            repository = _repository;
        }
        public async Task<Perfil> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

        public async Task Editar(Perfil perfil)
        {
            //Validar entidade
            await repository.Editar(perfil);
        }

        public async Task Excluir(string Id)
        {
            await repository.Excluir(Id);
        }

        public async Task<IEnumerable<Perfil>> Listar()
        {
            return await repository.Listar();
        }

        public async Task<bool> Salvar(Perfil perfil)
        {
            if (!ExecutarValidacao(new PermissaoValidation(), perfil)) return false;

            return await repository.Salvar(perfil);
        }

        public async Task<bool> RemoverPerfilUsuario(Perfil perfil, Usuario usuario)
        {
            return await repository.RemoverPerfilUsuario(perfil, usuario);
        }

        public async Task<bool> SalvarPerfilUsuario(Perfil perfil, Usuario usuario)
        {
            try
            {
                if (!ExecutarValidacao(new UserValidation(), usuario)) return false;

                if (!ExecutarValidacao(new PermissaoValidation(), perfil)) return false;

                return await repository.SalvarPerfilUsuario(perfil, usuario);
            }
            catch (Exception ex)
            {
                //tratar erro
                return false;
            }
        }

        public async Task<List<Perfil>> RetornaPerfilUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Id)) return null;
            return await repository.RetornaPerfilUsuario(usuario);
        }
    }
}
