using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IProjetoRepository repository;
        public ProjetoService(INotificador notificador,
                              IProjetoRepository projetoRepository) : base(notificador)
        {
            repository = projetoRepository;
        }

        public async Task Adicionar(Projeto entity)
        {
            //TODO: Validação
            await repository.Adicionar(entity);
        }

        public async Task Atualizar(Projeto entity)
        {
            //TODO: Validação
            await repository.Atualizar(entity);
        }

        public async Task<Projeto> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

        public async Task Excluir(Projeto entity)
        {
            await repository.Excluir(entity);
        }

        public async Task<IEnumerable<Projeto>> Listar()
        {
            return await repository.Listar();
        }
    }
}
