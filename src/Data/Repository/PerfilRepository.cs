using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        string path = "perfil";

        public async Task<bool> Salvar(Perfil perfil)
        {
            var id = await this.Adicionar(perfil, path);
            return string.IsNullOrEmpty(id) == false;
        }

        public async Task<IEnumerable<Perfil>> Listar()
        {
            return (await this.Listar(path)).OrderBy(x => x.Descricao);
        }
        public async Task Editar(Perfil perfil)
        {
            await this.Atualizar(perfil, path);
        }

        public Task Excluir(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Perfil> BuscarPorId(string id)
        {
            return await this.ObterPorId(id, path);
        }

        public async Task<bool> SalvarPerfilUsuario(Perfil perfil, Usuario usuario)
        {
            var id = await this.Adicionar(perfil, $"users/{usuario.Id}/perfil");
            return string.IsNullOrEmpty(id) == false;
        }

        public async Task<List<Perfil>> RetornaPerfilUsuario(Usuario usuario)
        {           
            return await this.Listar($"users/{usuario.Id}/perfil");
        }

        public async Task<bool> RemoverPerfilUsuario(Perfil perfil, Usuario usuario)
        {
            try
            {
                await this.Remover(perfil, $"users/{usuario.Id}/perfil");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        } 
    }
}
