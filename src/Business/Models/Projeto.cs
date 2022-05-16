using Business.Core.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    [FirestoreData]
    public class Projeto : Entity
    {
        [FirestoreProperty]
        public string Titulo { get; set; }

        [FirestoreProperty]
        public string Descricao { get; set; }

        public Usuario Responsavel { get; set; }

        public List<Usuario> Participantes { get; set; }

        [FirestoreProperty]
        public DateTime DataInicio { get; set; }

        [FirestoreProperty]
        public DateTime DataFim { get; set; }

        [FirestoreProperty]
        public string IdCaixa { get; set; }

        public Caixa Caixa { get; set; }
    }
}
