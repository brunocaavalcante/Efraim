using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
using Business.Validations;

namespace Business.Services
{
    public class DepartamentoService : BaseService, IDepartamentoService
    {
        private readonly IDepartamentoRepository repository;
        public DepartamentoService(IDepartamentoRepository _repository,
                                    INotificador _notificador):base(_notificador)
        {
            repository = _repository;
        }
        
        public async Task Adicionar(Departamento entity)
        { 
            entity.DataCadastro = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);           
            if (!ExecutarValidacao(new DepartamentoValidation(), entity)) return;    
         
            await repository.Adicionar(entity);
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