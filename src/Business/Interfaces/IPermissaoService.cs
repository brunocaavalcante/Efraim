using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPermissaoService
    {
        #region Usuario X perfil
    
        Task EditarPermissaoUsuario(Perfil permissao);
        Task ExcluirPermissaoUsuario(string Id);
        Task<Perfil> BuscarPorIdUsuario(string id);
        Task<IEnumerable<Perfil>> ListarPermissaoUsuario();
        #endregion

        #region Perfil
     
        Task EditarPermissao(Perfil permissao);
        Task ExcluirPermissao(string Id);
        Task<Perfil> BuscarPorId(string id);
        #endregion
    }
}
