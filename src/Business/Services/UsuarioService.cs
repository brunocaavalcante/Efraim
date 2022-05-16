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
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository repository;
        private readonly IPerfilRepository perfilRepository;

        public UsuarioService(IUsuarioRepository _repository,
                             IPerfilRepository _perfilRepository,
                             INotificador notificador) : base(notificador)
        {
            repository = _repository;
            perfilRepository = _perfilRepository;
        }

        public async Task AdicionarUsuario(Usuario entity)
        {
            //validar entidade
            entity.DataNascimento = DateTime.SpecifyKind(entity.DataNascimento, DateTimeKind.Utc);

            if (!ExecutarValidacao(new UserValidation(), entity)) return;
            //salvar dados                     
            await repository.AdicionarUsuario(entity);
        }

        public async Task AtualizarUsuario(Usuario entity)
        {
            entity.DataNascimento = DateTime.SpecifyKind(entity.DataNascimento, DateTimeKind.Utc);
            if (!ExecutarValidacao(new UserValidation(), entity)) return;

            await repository.AtualizarUsuario(entity);
        }

        public async Task<Usuario> BuscarPorColuna(string nomeColuna, string valor)
        {
            return await repository.BuscarPorColuna(nomeColuna, valor);
        }

        public async Task<Usuario> BuscarPorId(string Id)
        {
            return await repository.BuscarPorId(Id);
        }

        public async Task ExcluirUsuario(Usuario entity)
        {
            await repository.ExcluirUsuario(entity);
        }

        public async Task<List<Usuario>> ListarTodos()
        {
            return await repository.ListarTodos();       
        }
    }
}