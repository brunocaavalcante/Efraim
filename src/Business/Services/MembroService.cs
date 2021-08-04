using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Business.Validations;
using Business.Core.Services;
using Business.Core.Intefaces;

namespace Business.Services
{
    public class MembroService : BaseService, IMembroService
    {
        private readonly IMembroRepository repository;

        public MembroService(IMembroRepository _repository, 
                             INotificador notificador):base(notificador)
        {
            repository = _repository;
        }
        
        public async Task AdicionarMembro(Membro entity)
        {
            //validar entidade
            entity.DataCadastro = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            entity.DataNascimento = DateTime.SpecifyKind(entity.DataNascimento,DateTimeKind.Utc);
             
             if (!ExecutarValidacao(new MembroValidation(), entity)) return;         
            //salvar dados                     
            await repository.AdicionarMembro(entity);
        }

        public void AtualizarMembro(Membro entity)
        {
            throw new NotImplementedException();
        }

        public Membro BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirMembro(Membro entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Membro>> ListarTodos()
        {
            return await repository.ListarTodos();
        }
    }
}