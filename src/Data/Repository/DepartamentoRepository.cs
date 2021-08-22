using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Google.Cloud.Firestore;

namespace Data.Repository
{
    public class DepartamentoRepository : BaseRepository<Departamento>, IDepartamentoRepository
    {
        const string path = "departamentos";

        public async Task Adicionar(Departamento entity)
        {
            await this.Adicionar(entity,path);
        }

        public Task Atualizar(Departamento entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Excluir(Departamento entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Departamento>> Listar()
        {
            return await this.Listar(path);            
        }
    }
}