using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IMembroService
    {
        Task AdicionarMembro(Membro entity);
<<<<<<< HEAD
        void ExcluirMembro(Membro entity);
        void AtualizarMembro(Membro entity);
        Task<List<Membro>> ListarTodos();
        Membro BuscarPorId(Guid Id);
=======
        Task ExcluirMembro(Membro entity);
        Task AtualizarMembro(Membro entity);
        Task<List<Membro>> ListarTodos();
        Task<Membro> BuscarPorId(string Id);
>>>>>>> develop
    }
}
