using Business.Core.Intefaces;
using Business.Core.Services;
using Business.Interfaces;
using Business.Models;
using Business.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IProjetoRepository repository;
        private readonly ICaixaService caixaService;

        public ProjetoService(INotificador notificador,
                              IProjetoRepository projetoRepository,
                              ICaixaService _caixaService) : base(notificador)
        {
            repository = projetoRepository;
            caixaService = _caixaService;
        }

        public async Task Adicionar(Projeto entity)
        {
            if (!ExecutarValidacao(new ProjetoValidation(), entity)) return;

            entity.DataFim = DateTime.SpecifyKind(entity.DataFim, DateTimeKind.Utc);
            entity.DataInicio = DateTime.SpecifyKind(entity.DataInicio, DateTimeKind.Utc);
            await repository.Adicionar(entity);
        }

        public async Task Atualizar(Projeto entity)
        {
            if (!ExecutarValidacao(new ProjetoValidation(), entity)) return;

            entity.DataFim = DateTime.SpecifyKind(entity.DataFim, DateTimeKind.Utc);
            entity.DataInicio = DateTime.SpecifyKind(entity.DataInicio, DateTimeKind.Utc);
            await repository.Atualizar(entity);
        }

        public async Task<Projeto> BuscarPorId(string id)
        {
            var projeto = await repository.BuscarPorId(id);
            //projeto.Caixa = await caixaService.BuscarPorId(projeto.IdCaixa);
            return projeto;
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
