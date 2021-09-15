using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProjetoService
    {
        Task Adicionar(Projeto entity);
        Task Atualizar(Projeto entity);
        Task Excluir(Projeto entity);
        Task<IEnumerable<Projeto>> Listar();
        Task<Projeto> BuscarPorId(string id);
    }
}
