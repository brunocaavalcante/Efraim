using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PermissaoRepository : BaseRepository<Permissao>, IPermissaoRepository
    {
        private string path;

        public PermissaoRepository()
        {
            path = "permissoes";
        }
        public async Task EditarPermissao(Permissao permissao)
        {
           await this.Atualizar(permissao, path);
        }

        public Task ExcluirPermissao(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permissao>> ListarPermissao()
        {
            throw new NotImplementedException();
        }

        public async Task SalvarPermissao(Permissao permissao)
        {
            await this.Adicionar(permissao, path);
        }
    }
}
