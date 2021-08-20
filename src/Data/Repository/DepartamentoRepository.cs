using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;

namespace Data.Repository
{
    public class DepartamentoRepository : BaseRepository<Departamento>, IDepartamentoRepository
    {
        const string path = "departamentos";

        public Task Adicionar(Departamento entity)
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
    }
}