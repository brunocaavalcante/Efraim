using System;
using Google.Cloud.Firestore;
using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data.Repository
{
    public class MembroRepository : BaseRepository<Membro>,IMembroRepository
    {
        const string path = "membros";
    
        public async Task AdicionarMembro(Membro entity)
        {
            await this.Adicionar(entity,path);
        }

        public async Task<List<Membro>> ListarTodos()
        {
            var lista = new List<Membro>();
            var snapshot = await this.Listar(path);
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if(document.Exists)
                {
                    Membro membro = new Membro();
                    membro.Id = document.Id;
                    membro.DataCadastro = document.GetValue<DateTime>("DataCadastro");
                    membro.DataNascimento = document.GetValue<DateTime>("DataNascimento");
                    membro.CPF = document.GetValue<string>("CPF");
                    membro.Nome = document.GetValue<string>("Nome");
                    membro.Telefone = document.GetValue<string>("Telefone");
                    lista.Add(membro);
                }
            }
            return await Task.FromResult(lista);
        }

        public async Task<Membro> BuscarPorId(string Id)
        {
            Membro membro = new Membro();
            var document = await this.ObterPorId(Id, path);     

            if (document.Exists)
            {                
                membro.Id = document.Id;
                membro.DataCadastro = document.GetValue<DateTime>("DataCadastro");
                membro.DataNascimento = document.GetValue<DateTime>("DataNascimento");
                membro.CPF = document.GetValue<string>("CPF");
                membro.Nome = document.GetValue<string>("Nome");
                membro.Telefone = document.GetValue<string>("Telefone");                
            }
            return await Task.FromResult(membro);
        }

        public async Task ExcluirMembro(Membro entity)
        {
            await Remover(entity,path);
        }

        public async Task AtualizarMembro(Membro entity)
        {
            await this.Atualizar(entity,path);
        }      
    }
}