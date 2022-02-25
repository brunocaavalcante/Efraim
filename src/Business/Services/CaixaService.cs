using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CaixaService : BaseService, ICaixaService
    {
        private readonly ICaixaRepository repository;
        public CaixaService(ICaixaRepository caixaRepository, INotificador notificador) : base(notificador)
        {
            repository = caixaRepository;
        }

        public async Task<string> Adicionar(Caixa entity)
        {
            return await repository.Adicionar(entity);
        }

        public async Task Atualizar(Caixa entity)
        {
            await repository.Atualizar(entity);
        }

        public async Task<Caixa> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

        public async Task Excluir(Caixa entity)
        {
            await repository.Excluir(entity); 
        }

        public async Task<IEnumerable<Caixa>> Listar()
        {
            return await repository.Listar();
        }
    }
}
