using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IMembroService
    {
        Task AdicionarMembro(Membro entity);
        Task ExcluirMembro(Membro entity);
        Task AtualizarMembro(Membro entity);
        Task<List<Membro>> ListarTodos();
        Task<Membro> BuscarPorId(string Id);
        Task<Membro> BuscarPorColuna(string nomeColuna, string valor);
    }
}
