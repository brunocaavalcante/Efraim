using System;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMembroRepository
    {
        Task AdicionarMembro(Usuario entity);
        Task ExcluirMembro(Usuario entity);
        Task AtualizarMembro(Usuario entity);
        Task<List<Usuario>> ListarTodos();
        Task<Usuario> BuscarPorId(string Id);
        Task<Usuario> BuscarPorColuna(string nomeColuna, string valor);
    }
}