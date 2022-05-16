using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CaixaRepository : BaseRepository<Caixa>, ICaixaRepository
    {
        const string path = "caixas";
        public async Task<string> Adicionar(Caixa entity)
        {
            return await this.Adicionar(entity, path);
        }

        public async Task Atualizar(Caixa entity)
        {
            await this.Atualizar(entity, path);
        }

        public async Task<Caixa> BuscarPorId(string id)
        {
            return await this.ObterPorId(id, path);
        }

        public async Task Excluir(Caixa entity)
        {
            await this.Remover(entity, path);
        }

        public async Task<IEnumerable<Caixa>> Listar()
        {
            return await this.Listar(path);
        }
    }
}
