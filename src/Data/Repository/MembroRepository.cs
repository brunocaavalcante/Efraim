using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MembroRepository : BaseRepository<Membro>,IMembroRepository
    {
        const string path = "membros";
    
        public async Task AdicionarMembro(Membro entity)
        {
            await this.Adicionar(entity,path);
        }

        public async Task<List<Membro>> ListarTodos()
        {
            return await this.Listar(path);
        }

        public async Task<Membro> BuscarPorId(string Id)
        {
            return await this.ObterPorId(Id, path);    
        }

        public async Task ExcluirMembro(Membro entity)
        {
            await Remover(entity,path);
        }

        public async Task AtualizarMembro(Membro entity)
        {
            await this.Atualizar(entity,path);
        }      
    }
}