using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task Adicionar(Departamento entity);
        Task Atualizar(Departamento entity);
        Task Excluir(Departamento entity);
        Task<List<Departamento>> Listar();
        Task<Departamento> BuscarPorId(string id);
    }
}