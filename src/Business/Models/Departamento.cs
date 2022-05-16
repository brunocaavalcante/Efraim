using Business.Core.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    [FirestoreData]
    public class Departamento : Entity
    {
        public Departamento()
        {
            Lideres = new List<Usuario>();
            Membros = new List<Usuario>();
        }
        [FirestoreProperty]
        public string Nome { get; set; }

        [FirestoreProperty]
        public string Descricao { get; set; }

        [FirestoreProperty]
        public List<Usuario> Membros { get; set; }

        [FirestoreProperty]
        public List<Usuario> Lideres { get; set; }

        [FirestoreProperty]
        public DateTime DataCadastro { get; set; }

    }
}