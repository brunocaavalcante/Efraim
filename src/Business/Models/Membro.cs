using System;
using Google.Cloud.Firestore; 
using Business.Core.Models;

namespace Business.Models
{
    [FirestoreData] 
    public class Membro:Entity
    {
        [FirestoreProperty] 
        public string CPF { get; set; }

        [FirestoreProperty] 
        public string Nome { get; set; }

        [FirestoreProperty] 
        public DateTime DataNascimento { get; set; }

        [FirestoreProperty] 
        public DateTime DataCadastro { get; set; }
        
        [FirestoreProperty] 
        public string Telefone { get; set; }
    }
}