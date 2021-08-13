using System;
using System.Threading.Tasks;
using Business.Core.Models;
using Google.Cloud.Firestore;

namespace Data.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : Entity
    {
        protected FirestoreDb Db;
      
        private FirestoreDb Conexao()
        {
            string filepath = "..\\Web\\efraim-65b10-95921623748b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            return FirestoreDb.Create("efraim-65b10");
        }

        public virtual async Task Remover(Entity entity,string path)
        {
            Db = Conexao();
            DocumentReference document = Db.Collection(path).Document(entity.Id);
            await document.DeleteAsync();
        }

        protected virtual async Task Adicionar(TEntity entity, string path)
        {
            this.Db = Conexao();          
            CollectionReference colRef = Db.Collection(path);  
            await colRef.AddAsync(entity);            
        }

        protected virtual async Task Atualizar(TEntity entity,string path)
        {
            this.Db = Conexao();           
            DocumentReference document = Db.Collection(path).Document(entity.Id);
            await document.SetAsync(entity, SetOptions.Overwrite);          
        }
        
        protected virtual async Task<DocumentSnapshot> ObterPorId(string id,string path)
        {
            try
            {
                Db = Conexao();
                DocumentReference docRef = Db.Collection(path).Document(id);
                return await docRef.GetSnapshotAsync();               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        protected virtual async Task<QuerySnapshot> Listar(string path)
        {
            this.Db = Conexao();
            var usersRef = Db.Collection(path);          
            try
            {
                return await usersRef.GetSnapshotAsync();               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }  
}