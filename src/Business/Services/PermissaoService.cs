using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
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

        public async Task<Permissao> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

        public Task<Permissao> BuscarPorIdUsuario(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task EditarPermissao(Permissao permissao)
        {
            //Validar entidade
            await repository.EditarPermissao(permissao);
        }

        public Task EditarPermissaoUsuario(Permissao permissao)
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

        public async Task<IEnumerable<Permissao>> ListarPermissao()
        {
            return await repository.ListarPermissao();
        }

        public Task<IEnumerable<Permissao>> ListarPermissaoUsuario()
        {
            throw new System.NotImplementedException();
        }

        public async Task SalvarPermissao(Permissao permissao)
        {
            //Validar entidade

            await repository.SalvarPermissao(permissao);
        }

        public Task SalvarPermissaoUsuario(Permissao permissao)
        {
            throw new System.NotImplementedException();
        }
    }
}
