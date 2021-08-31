using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AdicionarMembro(Departamento entity, Membro membro)
        {
            bool membroJaExiste = entity.Membros.Where(m => m.CPF == membro.CPF).Any();

            if(!membroJaExiste)
            {
                entity.Membros.Add(membro);            
                await Atualizar(entity);
            }
            else
            {
                Notificar("Membro já é participante deste departamento!");   
            }            
        }

        public async Task Atualizar(Departamento entity)
        {
            entity.DataCadastro = DateTime.SpecifyKind(entity.DataCadastro,DateTimeKind.Utc);
            if (!ExecutarValidacao(new DepartamentoValidation(), entity)) return;
            
            await repository.Atualizar(entity);
        }

        public Task Excluir(Departamento entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Departamento>> Listar()
        {
            return await repository.Listar();
        }

        public Task RemoverMembro(Departamento entity, Membro membro)
        {
            throw new System.NotImplementedException();
        }    

        public async Task<Departamento> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

       
    }
}