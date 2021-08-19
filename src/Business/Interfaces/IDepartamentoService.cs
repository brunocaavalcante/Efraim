using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IDepartamentoService
    {
        Task Adicionar(Departamento entity);
        Task Atualizar(Departamento entity);
        Task Excluir(Departamento entity);
        Task<List<Departamento>> Listar();

        Task AdicionarMembro(Departamento entity, Membro membro);
        Task RemoverMembro(Departamento entity, Membro membro);
    }
}