using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICaixaService
    {
        Task<string> Adicionar(Caixa entity);
        Task Atualizar(Caixa entity);
        Task Excluir(Caixa entity);
        Task<IEnumerable<Caixa>> Listar();
        Task<Caixa> BuscarPorId(string id);
    }
}
