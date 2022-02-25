using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPermissaoService
    {
        Task SalvarPermissao(Permissao permissao);
        Task EditarPermissao(Permissao permissao);
        Task ExcluirPermissao(string Id);
        Task<IEnumerable<Permissao>> ListarPermissao();
    }
}
