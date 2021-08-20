using System.Collections.Generic;
using Business.Core.Models;
using Google.Cloud.Firestore;

namespace Business.Models
{
    [FirestoreData] 
    public class Departamento : Entity
    {
        [FirestoreProperty] 
        public string Nome{ get; set;}
        
        [FirestoreProperty] 
        public string Descricao {get;set;}

        [FirestoreProperty] 
        public List<Membro> Membros{ get; set; }

        [FirestoreProperty] 
        public List<Membro> Lider{ get; set; }

        [FirestoreProperty] 
        public Timestamp DataCadastro {get;set;}

    }
}