using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        string path = "users";

        public async Task AdicionarUsuario(Usuario entity)
        {
            await this.Adicionar(entity, path);
        }

        public async Task<List<Usuario>> ListarTodos()
        {
            return await this.Listar(path);
        }

        public async Task<Usuario> BuscarPorId(string Id)
        {
            return await this.ObterPorId(Id, path);
        }

        public async Task<Usuario> BuscarPorColuna(string nomeColuna, string valor)
        {
            return await BuscarPorColuna(path, nomeColuna, valor);
        }

        public async Task ExcluirUsuario(Usuario entity)
        {
            await Remover(entity, path);
        }

        public async Task AtualizarUsuario(Usuario entity)
        {
            await this.Atualizar(entity, path);
        }
       
    }
}