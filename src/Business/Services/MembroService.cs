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
        
        public async Task AdicionarMembro(Usuario entity)
        {
            //validar entidade
            entity.DataNascimento = DateTime.SpecifyKind(entity.DataNascimento,DateTimeKind.Utc);
             
             if (!ExecutarValidacao(new MembroValidation(), entity)) return;         
            //salvar dados                     
            await repository.AdicionarMembro(entity);
        }

        public async Task AtualizarMembro(Usuario entity)
        {
            entity.DataNascimento = DateTime.SpecifyKind(entity.DataNascimento,DateTimeKind.Utc);
           if (!ExecutarValidacao(new MembroValidation(), entity)) return;  

            await repository.AtualizarMembro(entity);
        }

        public async Task<Usuario> BuscarPorColuna(string nomeColuna, string valor)
        {
            return await repository.BuscarPorColuna(nomeColuna, valor);
        }

        public async Task<Usuario> BuscarPorId(string Id)
        {
            return await repository.BuscarPorId(Id);
        }

        public async Task ExcluirMembro(Usuario entity)
        {
           await repository.ExcluirMembro(entity);
        }

        public async Task<List<Usuario>> ListarTodos()
        {
            return await repository.ListarTodos();            
        }
    }
}