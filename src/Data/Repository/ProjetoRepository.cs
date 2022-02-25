using Business.Interfaces;
using Business.Models;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProjetoRepository : BaseRepository<Projeto>, IProjetoRepository
    {
        const string path = "projetos";
        public async Task Adicionar(Projeto entity)
        {
            await this.Adicionar(entity, path);
        }

        public async Task Atualizar(Projeto entity)
        {
            await this.Atualizar(entity, path);
        }

        public async Task<Projeto> BuscarPorId(string id)
        {
            var projeto = await this.ObterPorId(id, path);
            projeto.Participantes = await ListarParticipantes(projeto);
            return await Task.FromResult(projeto);
        }

        public async Task Excluir(Projeto entity)
        {
            await this.Remover(entity, path);
        }

        public async Task<IEnumerable<Projeto>> Listar()
        {
            return await this.Listar(path);
        }

        protected async Task<List<Usuario>> ListarParticipantes(Projeto projeto)
        {
            this.Db = Conexao();
            var usersRef = Db.Collection("projetos/" + projeto.Id + "/participantes");
            var snapshot = await usersRef.GetSnapshotAsync();
            var lista = new List<Usuario>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    Usuario entity = document.ConvertTo<Usuario>();
                    entity.Id = document.Id;
                    lista.Add(entity);
                }
            }

            return await Task.FromResult(lista);
        }
    }
}
