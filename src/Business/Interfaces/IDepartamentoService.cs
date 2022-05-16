using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDepartamentoService
    {
        Task Adicionar(Departamento entity);
        Task Atualizar(Departamento entity);
        Task Excluir(Departamento entity);
        Task<List<Departamento>> Listar();
        Task<Departamento> BuscarPorId(string id);
        Task AdicionarMembro(Departamento entity, Usuario membro);
        Task RemoverMembro(Departamento entity, Usuario membro);
        Task AdicionarLider(Departamento entity, Usuario lider);
        Task RemoverLider(Departamento entity, Usuario lider);
    }
}