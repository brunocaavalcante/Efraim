using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProjetoRepository : BaseRepository<Projeto>, IProjetoRepository
    {
        const string path = "projetos";
        public async Task Adicionar(Projeto entity)
        {
            await this.Adicionar(entity, path);
        }

        public async Task Atualizar(Projeto entity)
        {
            await this.Atualizar(entity, path);
        }

        public async Task<Projeto> BuscarPorId(string id)
        {
            return await this.ObterPorId(id, path);
        }

        public async Task Excluir(Projeto entity)
        {
            await this.Remover(entity, path);
        }

        public async Task<IEnumerable<Projeto>> Listar()
        {
            return await this.Listar(path);
        }
    }
}
