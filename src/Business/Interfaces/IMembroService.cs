using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IMembroService
    {
        Task AdicionarMembro(Usuario entity);
        Task ExcluirMembro(Usuario entity);
        Task AtualizarMembro(Usuario entity);
        Task<List<Usuario>> ListarTodos();
        Task<Usuario> BuscarPorId(string Id);
        Task<Usuario> BuscarPorColuna(string nomeColuna, string valor);
    }
}
