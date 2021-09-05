using System;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMembroRepository
    {
        Task AdicionarMembro(Membro entity);
        Task ExcluirMembro(Membro entity);
        Task AtualizarMembro(Membro entity);
        Task<List<Membro>> ListarTodos();
        Task<Membro> BuscarPorId(string Id);
        Task<Membro> BuscarPorColuna(string nomeColuna, string valor);
    }
}