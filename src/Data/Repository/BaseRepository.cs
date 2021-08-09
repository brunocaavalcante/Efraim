using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace Data.Repository
{
    public abstract class BaseRepository<TEntity>
    {
        protected FirestoreDb Db;

      
        private FirestoreDb Conexao()
        {
            string filepath = "C:\\Users\\bruno\\source\\repos\\EFRAIM\\src\\Web\\efraim-65b10-95921623748b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            return FirestoreDb.Create("efraim-65b10");
        }

        public virtual async Task Adicionar(TEntity entity, string path)
        {
            this.Db = Conexao();          
            CollectionReference colRef = Db.Collection(path);  
            await colRef.AddAsync(entity);            
        }

        public virtual async Task<DocumentSnapshot> ObterPorId(string id,string path)
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
        
        protected async Task<QuerySnapshot> Listar(string path)
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