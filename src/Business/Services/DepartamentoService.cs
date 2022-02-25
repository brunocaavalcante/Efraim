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
                                    INotificador _notificador) : base(_notificador)
        {
            repository = _repository;
        }

        public async Task Adicionar(Departamento entity)
        {
            entity.DataCadastro = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            if (!ExecutarValidacao(new DepartamentoValidation(), entity)) return;

            await repository.Adicionar(entity);
        }

        public async Task AdicionarMembro(Departamento entity, Usuario membro)
        {
            bool membroJaExiste = entity.Membros.Where(m => m.CPF == membro.CPF).Any();

            if (!membroJaExiste)
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
            entity.DataCadastro = DateTime.SpecifyKind(entity.DataCadastro, DateTimeKind.Utc);
            if (!ExecutarValidacao(new DepartamentoValidation(), entity)) return;

            await repository.Atualizar(entity);
        }

        public async Task Excluir(Departamento entity)
        {
            await repository.Excluir(entity);
        }

        public async Task<List<Departamento>> Listar()
        {
            return await repository.Listar();
        }

        public async Task RemoverMembro(Departamento entity, Usuario membro)
        {
            membro = entity.Membros.Where(m => m.CPF == membro.CPF).FirstOrDefault();
            entity.Membros.Remove(membro);
            await Atualizar(entity);
        }

        public async Task<Departamento> BuscarPorId(string id)
        {
            return await repository.BuscarPorId(id);
        }

        public async Task AdicionarLider(Departamento entity, Usuario lider)
        {           
            if (!ExecutarValidacao(new MembroValidation(), lider)) return;

            bool liderJaExiste = entity.Lideres.Where(m => m.CPF == lider.CPF).Any();
            bool isMembro = entity.Membros.Where(m => m.CPF == lider.CPF).Any();

            if (!isMembro) { Notificar("Membro não adicionado ao departamento"); return; }

            if (liderJaExiste) { Notificar("Lider já adicionado ao departamento!"); return; }

            entity.Lideres.Add(lider);
            await Atualizar(entity);
        }

        public async Task RemoverLider(Departamento entity, Usuario lider)
        {
            lider = entity.Lideres.Where(m => m.CPF == lider.CPF).FirstOrDefault();
            entity.Lideres.Remove(lider);
            await Atualizar(entity);
        }
    }
}