using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        public DepartamentoService()
        {
            
        }
        
        public Task Adicionar(Departamento entity)
        {
            throw new System.NotImplementedException();
        }

        public Task AdicionarMembro(Departamento entity, Membro membro)
        {
            throw new System.NotImplementedException();
        }

        public Task Atualizar(Departamento entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Excluir(Departamento entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Departamento>> Listar()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoverMembro(Departamento entity, Membro membro)
        {
            throw new System.NotImplementedException();
        }
    }
}