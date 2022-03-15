using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Permissao> BuscarPorId(string id)
        {
            return await this.ObterPorId(id, path);
        }

        public Task<Permissao> BuscarPorIdUsuario(string id)
        {
            throw new NotImplementedException();
        }

        public async Task EditarPermissao(Permissao permissao)
        {
            await this.Atualizar(permissao, path);
        }

        public Task EditarPermissaoUsuario(Permissao permissao)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirPermissao(string Id)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirPermissaoUsuario(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Permissao>> ListarPermissao()
        {
            return (await this.Listar(path)).OrderBy(x => x.Perfil);
        }

        public Task<IEnumerable<Permissao>> ListarPermissaoUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task SalvarPermissao(Permissao permissao)
        {
            await this.Adicionar(permissao, path);
        }

        public Task SalvarPermissaoUsuario(Permissao permissao)
        {
            throw new NotImplementedException();
        }
    }
}
