using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
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

        public async Task EditarPermissao(Permissao permissao)
        {
            //Validar entidade
            await repository.EditarPermissao(permissao);
        }

        public async Task ExcluirPermissao(string Id)
        {
            await repository.ExcluirPermissao(Id);
        }

        public async Task<IEnumerable<Permissao>> ListarPermissao()
        {
            return await repository.ListarPermissao();
        }

        public async Task SalvarPermissao(Permissao permissao)
        {
            //Validar entidade

            await repository.SalvarPermissao(permissao);
        }
    }
}
