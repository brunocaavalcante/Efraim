using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioService
    {
        Task AdicionarUsuario(Usuario entity);
        Task ExcluirUsuario(Usuario entity);
        Task AtualizarUsuario(Usuario entity);
        Task<List<Usuario>> ListarTodos();
        Task<Usuario> BuscarPorId(string Id);
        Task<Usuario> BuscarPorColuna(string nomeColuna, string valor);
    }
}
