using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPermissaoService
    {
        #region Permissao X Usuario
        Task SalvarPermissaoUsuario(Permissao permissao);
        Task EditarPermissaoUsuario(Permissao permissao);
        Task ExcluirPermissaoUsuario(string Id);
        Task<Permissao> BuscarPorIdUsuario(string id);
        Task<IEnumerable<Permissao>> ListarPermissaoUsuario();
        #endregion

        #region Permissao X Perfil
        Task SalvarPermissao(Permissao permissao);
        Task EditarPermissao(Permissao permissao);
        Task ExcluirPermissao(string Id);
        Task<Permissao> BuscarPorId(string id);
        Task<IEnumerable<Permissao>> ListarPermissao();
        #endregion
    }
}
