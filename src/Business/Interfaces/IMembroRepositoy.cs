using System;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMembroRepository
    {
        Task AdicionarMembro(Membro entity);
        void ExcluirMembro(Membro entity);
        void AtualizarMembro(Membro entity);
        Task<List<Membro>> ListarTodos();
        Membro BuscarPorId(Guid Id);
    }
}