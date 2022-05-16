using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPerfilService
    {
        Task<bool> Salvar(Perfil perfil);
        Task<IEnumerable<Perfil>> Listar();
        Task Editar(Perfil perfil);
        Task Excluir(string Id);
        Task<Perfil> BuscarPorId(string id);
        Task<bool> SalvarPerfilUsuario(Perfil perfil, Usuario usuario);
        Task<bool> RemoverPerfilUsuario(Perfil perfil, Usuario usuario);
        Task<List<Perfil>> RetornaPerfilUsuario(Usuario usuario);
    }
}
