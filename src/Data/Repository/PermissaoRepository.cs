using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PermissaoRepository : BaseRepository<Perfil>, IPermissaoRepository
    {
        private string path;

        public PermissaoRepository()
        {
            path = "permissoes";
        }

        public async Task<Perfil> BuscarPorId(string id)
        {
            return await this.ObterPorId(id, path);
        }

        public Task<Perfil> BuscarPorIdUsuario(string id)
        {
            throw new NotImplementedException();
        }

        public async Task EditarPermissao(Perfil permissao)
        {
            await this.Atualizar(permissao, path);
        }

        public Task EditarPermissaoUsuario(Perfil permissao)
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

        public Task<IEnumerable<Perfil>> ListarPermissaoUsuario()
        {
            throw new NotImplementedException();
        }

       
    }
}
