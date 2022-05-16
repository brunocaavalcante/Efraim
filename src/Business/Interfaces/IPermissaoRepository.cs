using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPermissaoRepository
    {
        #region Perfil X Usuario
        Task EditarPermissaoUsuario(Perfil permissao);
        Task ExcluirPermissaoUsuario(string Id);
        Task<Perfil> BuscarPorIdUsuario(string id);
        #endregion

        #region Permissao 
     
        Task EditarPermissao(Perfil permissao);
        Task ExcluirPermissao(string Id);
        Task<Perfil> BuscarPorId(string id);
        #endregion
    }
}
