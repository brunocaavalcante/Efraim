using Business.Core.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected FirestoreDb Db;

        protected FirestoreDb Conexao()
        {

            if (Environment.CurrentDirectory.Contains("tests"))
            {              
                string filepath = "efraim-key-dev.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
                return FirestoreDb.Create("efraim-dev");
            }
            else 
            {
                string filepath = "..\\Web\\efraim-key.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
                return FirestoreDb.Create("efraim-65b10");
            }
        }

        public virtual async Task Remover(Entity entity, string path)
        {
            Db = Conexao();
            DocumentReference document = Db.Collection(path).Document(entity.Id);
            await document.DeleteAsync();
        }

        protected virtual async Task<string> Adicionar(TEntity entity, string path)
        {
            try
            {
                this.Db = Conexao();
                CollectionReference colRef = Db.Collection(path);
                var result = await colRef.AddAsync(entity);
                return result.Id;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        protected virtual async Task Atualizar(TEntity entity, string path)
        {
            this.Db = Conexao();
            DocumentReference document = Db.Collection(path).Document(entity.Id);
            await document.SetAsync(entity, SetOptions.Overwrite);
        }

        protected virtual async Task<TEntity> ObterPorId(string id, string path)
        {
            Db = Conexao();
            DocumentReference docRef = Db.Collection(path).Document(id);
            var document = await docRef.GetSnapshotAsync();
            var entity = new TEntity();

            if (document.Exists)
            {
                entity = document.ConvertTo<TEntity>();
                entity.Id = document.Id;
            }
            return await Task.FromResult(entity);
        }

        protected virtual async Task<TEntity> BuscarPorColuna(string path, string coluna, string value)
        {
            Db = Conexao();
            var docRef = Db.Collection(path);
            var query = docRef.WhereEqualTo(coluna, value);
            var document = await query.GetSnapshotAsync();
            var entity = new TEntity();

            foreach (DocumentSnapshot item in document.Documents)
            {
                entity = item.ConvertTo<TEntity>();
                entity.Id = item.Id;
            }

            return await Task.FromResult(entity);
        }

        protected virtual async Task<List<TEntity>> Listar(string path)
        {
            try
            {
                this.Db = Conexao();
                var usersRef = Db.Collection(path);
                var snapshot = await usersRef.GetSnapshotAsync();
                var lista = new List<TEntity>();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        TEntity entity = document.ConvertTo<TEntity>();
                        entity.Id = document.Id;
                        lista.Add(entity);
                    }
                }

                return await Task.FromResult(lista);
            }
            catch (Exception ex) { return null; }
        }
    }
}