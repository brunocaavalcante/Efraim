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

        public async Task Atualizar(Departamento entity)
        {
            await this.Atualizar(entity, path);
        }

        public async Task<Departamento> BuscarPorId(string id)
        {
            return await this.ObterPorId(id, path);
        }

        public async Task Excluir(Departamento entity)
        {
            await this.Remover(entity, path);
        }

        public async Task<List<Departamento>> Listar()
        {
            return await this.Listar(path);            
        }
    }
}