using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
using Business.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PermissaoService : BaseService, IPermissaoService
    {
        private readonly IPermissaoRepository repository;
        public PermissaoService(INotificador notificador, IPermissaoRepository administracaoRepository) : base(notificador)
        {
            repository = administracaoRepository;
        }

        public async Task<Perfil> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

        public Task<Perfil> BuscarPorIdUsuario(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task EditarPermissao(Perfil permissao)
        {
            //Validar entidade
            await repository.EditarPermissao(permissao);
        }

        public Task EditarPermissaoUsuario(Perfil permissao)
        {
            throw new System.NotImplementedException();
        }

        public async Task ExcluirPermissao(string Id)
        {
            await repository.ExcluirPermissao(Id);
        }

        public Task ExcluirPermissaoUsuario(string Id)
        {
            throw new System.NotImplementedException();
        }


        public Task<IEnumerable<Perfil>> ListarPermissaoUsuario()
        {
            throw new System.NotImplementedException();
        }

     
    }
}
