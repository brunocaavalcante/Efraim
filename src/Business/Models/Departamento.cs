using System;
using System.Collections.Generic;
using Business.Core.Models;
using Google.Cloud.Firestore;

namespace Business.Models
{
    [FirestoreData] 
    public class Departamento : Entity
    {
        public Departamento()
        {
            Lideres = new List<Membro>();
            Membros = new List<Membro>();
        }
        [FirestoreProperty] 
        public string Nome{ get; set;}
        
        [FirestoreProperty] 
        public string Descricao {get;set;}

        [FirestoreProperty] 
        public List<Membro> Membros{ get; set; }

        [FirestoreProperty] 
        public List<Membro> Lideres{ get; set; }

        [FirestoreProperty] 
        public DateTime DataCadastro {get;set;}

    }
}